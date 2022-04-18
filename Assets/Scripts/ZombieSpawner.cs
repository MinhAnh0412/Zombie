using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] ZombiePrefabs;
    public float interval;
    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnZombie), interval, interval);

    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void SpawnZombie()
    {

        var index = UnityEngine.Random.Range(0, ZombiePrefabs.Length);
        Instantiate(ZombiePrefabs[index], transform.position, transform.rotation);
    }
}
