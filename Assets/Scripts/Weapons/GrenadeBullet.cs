using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        var hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        DeliverDamage(hitColliders);
        BlowObjects(hitColliders);
        Destroy(gameObject);
    }
    private List<ZombieHealth> victims = new List<ZombieHealth>();

    private void DeliverDamage(Collider[] hitColliders)
    {
        victims.Clear();
        for (int i =0; i< hitColliders.Length; i++)
        {
            var zombieHealth = hitColliders[i].GetComponentInParent<ZombieHealth>();
            if (zombieHealth == null || victims.Contains(zombieHealth)) continue;
            
                zombieHealth.TakeDamage(damage);
                victims.Add(zombieHealth);
            
        }
    }

    private void BlowObjects(Collider[] hitColliders)
    {
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].attachedRigidbody == null) continue;
            hitColliders[i].attachedRigidbody.AddExplosionForce(
                explosionForce, transform.position, explosionRadius, 1f, ForceMode.Impulse);
        }
    }
}
