using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
   
    PlayerHealth target;
    [SerializeField] float damage = 40f;


    void Start() {
        target = FindObjectOfType<PlayerHealth>();
    }

    // public void OnDamageFromPlayer() {
    //     Debug.Log(name + " I took damage...");
    // }

    public void AttackHitEvent() {

        if (target == null) {
            return;
        }

        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImg();
        
    }

 
}
