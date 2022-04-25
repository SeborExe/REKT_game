using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 2f;
    [SerializeField] float delayShoot = 0.5f;
    [SerializeField] ParticleSystem shootParticle;
    [SerializeField] GameObject hitSparksParticle;
    [SerializeField] AmmoType ammoType;

    Ammo ammoSlot;

    bool canShoot = true;

    private void Start()
    {
        ammoSlot = GetComponentInParent<Ammo>();
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayShootParticles();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(delayShoot);
        canShoot = true;
    }

    private void PlayShootParticles()
    {
        shootParticle.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var sparks = Instantiate(hitSparksParticle, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(sparks, 0.1f);
    }
}
