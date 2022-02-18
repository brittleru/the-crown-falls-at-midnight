using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour {
  
    [SerializeField] Camera povCamera;
    [SerializeField] RigidbodyFirstPersonController povController;
    [SerializeField] float maxZoomOut = 60f;
    [SerializeField] float maxZoomIn = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;  // both x and y sensitivity
    [SerializeField] float zoomInSensitivity = 0.5f; // both x and y sensitivity

    bool isZoomedIn = false;

    // void Start() {
    //     povController = GetComponentInParent<RigidbodyFirstPersonController>();
    // }

    private void OnDisable() {
        ZoomOut();  // fixed bug were switching weapon let view zoomed in
    }

    void Update() {
        
        // zoom in and out feature 
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (!isZoomedIn){
                ZoomIn();
            }
            else {
                ZoomOut();
            }
        }

    }


    private void ZoomIn() {
        isZoomedIn = true;
        povCamera.fieldOfView = maxZoomIn;
        povController.mouseLook.XSensitivity = zoomInSensitivity;
        povController.mouseLook.YSensitivity = zoomInSensitivity;
    }
    private void ZoomOut() {
        isZoomedIn = false;
        povCamera.fieldOfView = maxZoomOut;
        povController.mouseLook.XSensitivity = zoomOutSensitivity;
        povController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    
}
