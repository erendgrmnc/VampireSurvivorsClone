using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpManager : MonoBehaviour
{
    public float CurrentExp { get; set; }
    public int CurrentPlayerLevel { get; set; }

    public ProgressBar progressBar;

    public float ExpToNextLevel { get; private set; }

    const float expToNextLevelMultiplier = 2;
    const float startExp = 100;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        CurrentPlayerLevel = 0;
        CurrentExp = 0;

        ExpToNextLevel = startExp;

        progressBar.InitBar(CurrentExp, ExpToNextLevel);
    }

    void CheckIsPlayerLevelUp()
    {
        if (CurrentExp > ExpToNextLevel)
        {
            CurrentPlayerLevel++;
            CurrentExp = 0;
            ExpToNextLevel *= expToNextLevelMultiplier;
            progressBar.InitBar(CurrentExp, ExpToNextLevel);
        }
    }

    public void AddExpToPlayer(float expAmount)
    {
        CurrentExp += expAmount;
        progressBar.BarValue = CurrentExp;
        CheckIsPlayerLevelUp();
    }
}
