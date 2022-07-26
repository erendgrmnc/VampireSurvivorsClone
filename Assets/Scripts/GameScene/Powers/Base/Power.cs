using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    AxeThrow
}

public abstract class Power : MonoBehaviour
{
    [SerializeField]
    protected GameObject powerPrefab;
    [SerializeField]
    protected float damage = 10f;
    [SerializeField]
    protected bool isTimeDestroyable = false;
    [SerializeField]
    protected bool isDestroyableOnHit = false;
    [SerializeField]
    protected float destroyTime = 5f;
    [SerializeField] public PowerType PowerType { get; protected set; }

    protected virtual void SpawnPowerObject(Vector3 spawnPosition)
    {
        if (powerPrefab)
        {
            powerPrefab.SetActive(true);
            powerPrefab.transform.position = spawnPosition;
        }
    }

    protected virtual void DeactivatePowerObject()
    {
        if (powerPrefab)
        {
            powerPrefab.SetActive(false);
        }
    }
}
