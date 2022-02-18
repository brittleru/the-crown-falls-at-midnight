using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour {

    // [SerializeField] int numberOfArrows = 10;
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable] // how the content from this class into the inspector
    private class AmmoSlot {
        public AmmoType ammoType;
        public int numberOfArrows;
    }

    public int GetNumberOfArrows(AmmoType ammoType) {
        return GetAmmoSlot(ammoType).numberOfArrows;
    }

    public void ReduceCurrentArrows(AmmoType ammoType) {
        GetAmmoSlot(ammoType).numberOfArrows -= 1;
    }

    public void IncreaseCurrentArrows(AmmoType ammoType, int ammoAmount) {
        GetAmmoSlot(ammoType).numberOfArrows += ammoAmount;
    }

    void Start() {
        
    }

    void Update() {
        
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType) {

        foreach (AmmoSlot ammoSlot in ammoSlots) {
            if (ammoSlot.ammoType == ammoType) {
                return ammoSlot;
            }
        }
        return null;

    }



}
