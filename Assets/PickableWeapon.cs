using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableWeapon : MonoBehaviour
{
    public int gunIndex;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<GunSwitcher>(out var gunSwitcher))
        {
            if(gunSwitcher.IsPickUpGun(gunIndex))
            {
                gunSwitcher.PickUpGun(gunIndex);
                Destroy(gameObject);
            }
         
        }
    }
}
