using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickup : MonoBehaviour {

    [SerializeField] int arrowAmmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            FindObjectOfType<AmmoHandler>().IncreaseCurrentArrows(ammoType, arrowAmmount);
            Destroy(gameObject);
        }   


    }

    void Start() {
        
    }


    void Update() {
        
    }

}
