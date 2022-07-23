using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : MonoBehaviour
{
    [SerializeField]
    protected GameObject powerPrefab;
    [SerializeField]
    protected float damage = 10f;
    [SerializeField]
    protected bool isTimeDestroyable = false;
    [SerializeField]
    protected float destroyTime = 5f;

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
