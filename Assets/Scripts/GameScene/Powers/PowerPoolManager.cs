using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPoolManager : Spawner
{
    public void InitPowerPool(string powerName)
    {
        InitPool(powerName);
    }

    public GameObject GetPooledPower()
    {
        return GetPooledObject();
    }

    public void SetPoolPower(GameObject poolPower, int amountToPool)
    {
        this.amountToPool = amountToPool;
        this.objectOfPool = poolPower.gameObject;
    }
}
