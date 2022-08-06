using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    AxeThrow
}

public abstract class Power : MonoBehaviour, IPower
{
    [SerializeField]
    protected float damage = 10f;
    [SerializeField]
    protected float destroyTime = 0f;
    [SerializeField] 
    protected float cooldown = 3f;
    [SerializeField]
    protected int poolAmount = 0;
   [SerializeField]
    protected bool isTimeDestroyable = false;
    [SerializeField]
    protected bool isDestroyableOnHit = false;
    [SerializeField]
    protected bool isCoolDownRequired = true;
    [SerializeField]
    public PowerType PowerType { get; protected set; }
    [SerializeField] 
    protected string powerName;

    public float GetPowerDamage()
    {
        return damage;
    }

    public float GetDestroyTime()
    {
        return destroyTime;
    }

    public float GetCooldownTime()
    {
        return cooldown;
    }

    public int GetPoolAmount()
    {
        return poolAmount;
    }

    public bool GetIsTimeDestroyable()
    {
        return isTimeDestroyable;
    }

    public bool GetIsCooldownRequired()
    {
        return isCoolDownRequired;
    }

    public bool GetIsDestroyableOnHit()
    {
        return isDestroyableOnHit;
    }

    public string GetPowerName()
    {
        return powerName;
    }

    public void InitPower()
    {
        throw new NotImplementedException();
    }
    
    public virtual IEnumerator DestroyInstance()
    {
        throw new NotImplementedException();
    }
}
