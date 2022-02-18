using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] Camera FirstPersonCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem arrowShootEffect;
    [SerializeField] GameObject enemyHitEffect;
    [SerializeField] AmmoHandler arrowSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    void Start() {
        
    }

    void OnEnable() {
        canShoot = true;    
    }

    void Update() {
        
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot) {
            StartCoroutine(FireArrow());
        }

    }

    private void DisplayAmmo() {

        int currentAmmo = arrowSlot.GetNumberOfArrows(ammoType);
        ammoText.text = $"Arrows: {currentAmmo}";

    }

    IEnumerator FireArrow() {
        canShoot = false;

        if (arrowSlot.GetNumberOfArrows(ammoType) > 0) {
            PlayShootEffect();
            ProcessRaycast();
            arrowSlot.ReduceCurrentArrows(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayShootEffect() {
        arrowShootEffect.Play();
    }

    private void ProcessRaycast() {
        RaycastHit hit;

        if (Physics.Raycast(FirstPersonCamera.transform.position, FirstPersonCamera.transform.forward, out hit, range))
        {

            ShowHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
            {
                return;
            }

            target.TakeDamage(damage);

            return;
        }
        else
        {
            return;
        }
    }

    private void ShowHitEffect(RaycastHit hit) {

        GameObject impact = Instantiate(enemyHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        impact.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(impact, 1f);

    }
}
