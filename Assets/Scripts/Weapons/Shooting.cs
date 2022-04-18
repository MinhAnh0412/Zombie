using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public abstract class Shooting : MonoBehaviour
{
    public Animator anim;
    public AudioSource shootSound;

    private void OnValidate() => anim = GetComponent<Animator>();

    protected abstract void Shoot();
}
