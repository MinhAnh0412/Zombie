using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int healthPoint;
    public UnityEvent onDead;
    public bool isDead => healthPoint <=0;

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        healthPoint -= damage;
        if(isDead)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        onDead.Invoke();
    }
}
