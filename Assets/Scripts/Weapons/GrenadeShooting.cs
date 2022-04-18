using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooting : Shooting
{
    public Rigidbody grenadePrefab;
    public Transform firingPos;
    public float launchingForce;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    protected override void Shoot() => anim.SetTrigger("Shoot");

    public void AddProjectile() 
    {
        var bullet = Instantiate(grenadePrefab, firingPos.position, firingPos.rotation);
        bullet.velocity = bullet.transform.forward * launchingForce;
    }

    public void PlayFireSound() =>  shootSound.Play();
}
