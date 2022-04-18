using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    public float speed;
    private Transform playerFoot;
    public NavMeshAgent navAgent;
    public Animator anim;
    public float stoppingDistance;
    public UnityEvent onTargetReached;
    public UnityEvent onStartChasing;

    private bool isChasingValue;

    public bool isChasing
    {
        get => isChasingValue;
        set{
            if (isChasingValue == value) return;

            isChasingValue = value;
            navAgent.isStopped = !isChasingValue;
            anim.SetBool("isChasing", isChasingValue);
            ThrowChasingEvents();
        }
    }

    private void ThrowChasingEvents()
    {
        if(isChasingValue == true)
        {
            onStartChasing.Invoke();
        }
        else
        {
            onTargetReached.Invoke();
        }
    }

    public void OnValidate() {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }
        // Start is called before the first frame update
    void Start()
    {
        playerFoot = GameObject.FindGameObjectWithTag("PlayerFoot").transform;
        anim.SetBool("isChasing", true);
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, playerFoot.position);
        isChasing = (distance > stoppingDistance);

        if (isChasing)
        {
            navAgent.SetDestination(playerFoot.position);
        }
    }
    public void OnDead()
    {
        enabled = false;
        navAgent.enabled = false;
    }
}
