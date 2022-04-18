using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : Shooting
{
    public int rpm;
    public Transform aimingCamera;
    public GameObject markerPrefab;
    public int damage;
    public float pushBackForce;

    private bool isFiring;
    private float lastShotTime;

    private void Update()
    {
        isFiring = Input.GetButton("Fire1");
        UpdateFiring();
    }

    private void UpdateFiring()
    {
        if (!isFiring) return;

        var interval = 60f / rpm;
        if (Time.time - lastShotTime > interval)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    protected override void Shoot()
    {
        anim.Play("AlternateSingleFire", -1, 0);
        shootSound.Play();
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        var aimingRay = new Ray(aimingCamera.position, aimingCamera.forward);
        if (Physics.Raycast(aimingRay, out var hitInfo))
        {
            DeliverDamage(hitInfo);
            PushBack(hitInfo, aimingRay);
            var rotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(markerPrefab, hitInfo.point, rotation);
        }
    }

    private void PushBack(RaycastHit hitInfo, Ray aimingRay)
    {
        if (hitInfo.collider.attachedRigidbody == null) return;
        hitInfo.collider.attachedRigidbody.AddForce(
            aimingRay.direction * pushBackForce, ForceMode.Impulse);
            
    }

    private void DeliverDamage(RaycastHit hitInfo)
    {
        var zombieHealth = hitInfo.collider.GetComponentInParent<ZombieHealth>();
        if(zombieHealth != null)
        {
            zombieHealth.TakeDamage(damage);
        }
    }
}
