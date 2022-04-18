using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    private Health playerHealth;
    public void OnValidate()
    {
        anim = GetComponent<Animator>();
    }
    public void StartAttack()
    {
        anim.SetBool("isAttacking", true);
        anim.applyRootMotion = true;
    }

    
    public void StopAttack()
    {
        anim.applyRootMotion = false;
        anim.SetBool("isAttacking", false);
    }
    public void FirstAttack()
    {
        playerHealth.TakeDamage(damage);
    }
    public void SecondAttack()
    {
        playerHealth.TakeDamage(damage);
    }
}
