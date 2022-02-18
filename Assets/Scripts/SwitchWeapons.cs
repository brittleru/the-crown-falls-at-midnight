using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour {

    [SerializeField] int currentWeapon = 0;


    void Start() {
        SetWeaponActive();
    }

    void Update() {
        int previousWeapon = currentWeapon;

        ProcessUserInput();

        if (previousWeapon != currentWeapon) {
            SetWeaponActive();
        }
    }


    private void ProcessUserInput() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeapon = 1;
        }
  

    }

    private void SetWeaponActive() {
        int weaponIndex = 0;

        foreach (Transform weapon in transform) {
            if (weaponIndex == currentWeapon) {
                weapon.gameObject.SetActive(true);
            }
            else {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex += 1;
        }


    }



}
