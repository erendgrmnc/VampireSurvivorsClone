using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrowPowerManager : PowerManager
{
    protected override void CommenceAttackWithCooldown()
    {
        var playerPosition = Player.Instance.gameObject.transform.position;
        powerPoolManager.SpawnObject(playerPosition);
    }

    protected override void CommenceAttackWithoutCooldown()
    {
        base.CommenceAttackWithoutCooldown();
    }
}
