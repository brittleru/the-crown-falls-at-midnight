using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour {

    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.2f;

    void Start() {
        impactCanvas.enabled = false;
    }

    public void ShowDamageImg() {
        StartCoroutine(ShowImage());
    }

    IEnumerator ShowImage() {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }

    void Update() {
        
    }
}
