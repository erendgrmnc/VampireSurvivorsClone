using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject powerPrefab;
    [SerializeField]
    protected PowerPoolManager powerPoolManager;

    public virtual void InitPowerManager()
    {
        InitPowerPoolManager();

        var powerComponent = powerPrefab.GetComponent<Power>();
        if (powerComponent != null)
        {
            if (powerComponent.GetIsCooldownRequired())
            {
                InvokeRepeating("CommenceAttackWithCooldown", 0f, powerComponent.GetCooldownTime());
            }
            else
            {
                CommenceAttackWithoutCooldown();
            }
        }
    }

    protected virtual void CommenceAttackWithCooldown()
    {
        throw new NotImplementedException();
    }

    protected virtual void CommenceAttackWithoutCooldown()
    {
        throw new NotImplementedException();
    }

    protected virtual void InitPowerPoolManager()
    {
        var powerComponent = powerPrefab.GetComponent<Power>();
        if (powerComponent)
        {
            powerPoolManager.SetPoolPower(powerPrefab, powerComponent.GetPoolAmount());
            powerPoolManager.InitPowerPool(powerComponent.GetPowerName());
        }
    }

    protected virtual void SpawnPowerObject(Vector3 spawnPosition)
    {
        if (powerPrefab && powerPrefab.gameObject)
        {
            powerPrefab.gameObject.SetActive(true);
            powerPrefab.gameObject.transform.position = spawnPosition;
        }
    }

    protected virtual void DeactivatePowerObject()
    {
        if (powerPrefab && powerPrefab.gameObject)
        {
            powerPrefab.gameObject.SetActive(false);
        }
    }

    public string GetPowerName()
    {
        var powerComponent = powerPrefab.GetComponent<Power>();

        if (powerComponent)
        {
            return powerComponent.GetPowerName();
        }
        else
        {
            return string.Empty;
        }
    }
}
