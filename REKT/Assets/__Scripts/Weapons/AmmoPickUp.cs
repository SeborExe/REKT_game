using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int bulletAmount = 5;
    [SerializeField] AmmoType ammoType;

    Ammo ammo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ammo = FindObjectOfType<Ammo>();
            ammo.IncreaseAmmo(ammoType, bulletAmount);
            Destroy(gameObject);
        }
    }
}
