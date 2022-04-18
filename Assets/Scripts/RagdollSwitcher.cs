using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] rigid;
    private void OnValidate()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponentsInChildren<Rigidbody>();
    }
    private void Start()
    {
        DisableRagdoll();
    }
    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll() => SetRadoll(false);
    

    private void SetRadoll(bool enableRagdoll)
    {
        anim.enabled = !enableRagdoll;
        for (int i =0; i < rigid.Length; i++)
        {
            rigid[i].isKinematic = !enableRagdoll;
        }
    }
    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll() => SetRadoll(true);
    
}
