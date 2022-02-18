using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {
    [SerializeField] Canvas gameWonUI;

    void Start() {
        gameWonUI.enabled = false;
    }

    public void HandleWin() {
        gameWonUI.enabled = true;
        Time.timeScale = 0; // to not have any conflicts with cursor and game
        FindObjectOfType<SwitchWeapons>().enabled = false;
        Cursor.lockState = CursorLockMode.None; // we want to mouse unlocked
        Cursor.visible = true;
    }

}
