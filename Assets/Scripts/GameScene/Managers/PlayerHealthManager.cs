using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public ProgressBar healthProgressBar;

    const float playerMaxHP = 100f;

    public float Health { get; private set; }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        Health = playerMaxHP;
        healthProgressBar.InitBar(Health, playerMaxHP);
    }

    public void DamagePlayer(float damage)
    {
        Health -= damage;
        healthProgressBar.InitBar(Health, playerMaxHP);
        CheckIsPlayerDied();
    }

    void CheckIsPlayerDied()
    {
        if (Health <= 0f)
        {
            //TODO: GAME OVER
            Time.timeScale = 0f;
        }
    }
}
