using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerPowerManager : MonoBehaviour
{
    private List<PowerData> powerDataList;
    private List<PowerData> unlockedPowerDataList;

    // Start is called before the first frame update

    void Awake()
    {
        InitPowerLists();
    }

    void Start()
    {
        Load();
        CreateUnlockedPowersList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitPowerLists()
    {
        powerDataList = new List<PowerData>();
        unlockedPowerDataList = new List<PowerData>();
    }

    void CreateUnlockedPowersList()
    {
        foreach (var power in powerDataList)
        {
            if (power.IsPowerUnlocked)
            {
                unlockedPowerDataList.Add(power);
            }
        }
    }

    string GetPath()
    {
        string path = Path.Combine(Application.dataPath, "powerTest.json");
        Debug.Log(path);
        return path;
    }

    void Load()
    {
        string powerDataPath = GetPath();
        powerDataList = JsonUtility.FromJson<List<PowerData>>(powerDataPath);
    }
}
