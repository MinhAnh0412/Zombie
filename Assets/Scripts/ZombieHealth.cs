using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieHealth : Health
{

    public Animator anim;
    private void OnValidate()
    {
        anim = GetComponent<Animator>();
    }
    protected override void Die() {
        base.Die();
        anim.SetTrigger("Die");
        Destroy(gameObject, 5f);
    }
}
