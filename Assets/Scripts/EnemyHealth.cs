using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] float hitPoints = 100f;

    float beforeWinTimeout = 3f;
    bool isDead = false;

    public bool IsDead() {
        return isDead;
    }

    public void TakeDamage(float damage) {

        // GetComponent<EnemyAI>().OnDamageFromPlayer();
        BroadcastMessage("OnDamageFromPlayer");

        hitPoints -= damage;

        if (hitPoints <= 0) {
            Death();
            if (FindObjectOfType<WinCondition>().gameObject == this.gameObject) {
                
                StartCoroutine(WinGame());
            }
        }
    }

    private void Death() {

        if (isDead) {
            return;
        }
        
        isDead = true;
        GetComponent<Animator>().SetTrigger("death");

        

    }

    IEnumerator WinGame() {

        yield return new WaitForSeconds(beforeWinTimeout);
        GetComponent<WinCondition>().HandleWin();

    }

}
