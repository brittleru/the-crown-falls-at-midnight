using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {
 
    [SerializeField] Canvas gameOverUI;

    void Start() {
        gameOverUI.enabled = false;
    }


    public void HandleDeath() {
        gameOverUI.enabled = true;
        Time.timeScale = 0; // to not have any conflicts with cursor and game
        FindObjectOfType<SwitchWeapons>().enabled = false;
        Cursor.lockState = CursorLockMode.None; // we want to mouse unlocked
        Cursor.visible = true;
    }

}
