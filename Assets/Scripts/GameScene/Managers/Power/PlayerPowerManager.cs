using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class PlayerPowerManager : MonoBehaviour
{
    [SerializeField, SerializeReference]
    private GameObject[] powerManagersList;

    private List<PowerData> powerDataList;
    private List<PowerData> unlockedPowerDataList;

    private GameObject powerManagers;


    void Awake()
    {
        InitPowerLists();
        InitPowerManagersGameObject();
    }

    void Start()
    {
        Load();
        CreateUnlockedPowersList();
    }
    
    void InitPowerManagersGameObject()
    {
        powerManagers = new GameObject("PowerManagers");
    }
    string GetPath()
    {
        string path = Path.Combine(Application.dataPath, "Data/powerData.json");
        return path;
    }

    void InitPowerLists()
    {
        powerDataList = new List<PowerData>();
        unlockedPowerDataList = new List<PowerData>();
    }

    void InitUnlockedPowerManager(PowerData powerData)
    {
        bool isInitableToScene = powerData != null;
        if (isInitableToScene)
        {
            var powerManagerGameObject = GetPowerManager(powerData.PowerName);

            var powerManagerToCreate = Instantiate(powerManagerGameObject, gameObject.transform.position,
                gameObject.transform.rotation);

            powerManagerToCreate.transform.parent = powerManagers.transform;

            var powerManagerComponent = powerManagerGameObject.GetComponent<PowerManager>();

            if (powerManagerComponent)
            {
                powerData.PowerManager = powerManagerComponent;
                powerManagerComponent.InitPowerManager();
            }
        }
    }

    GameObject GetPowerManager(string name)
    {
        foreach (var powerManager in powerManagersList)
        {
            var powerManagerComponent = powerManager.GetComponent<PowerManager>();

            if (powerManagerComponent)
            {
                var powerManagerName = powerManagerComponent.GetPowerName();
                if (!string.IsNullOrEmpty(powerManagerName) && powerManagerName == name)
                {
                    return powerManager;
                }
            }
        }

        return null;
    }

    void CreateUnlockedPowersList()
    {
        foreach (var powerData in powerDataList)
        {
            if (powerData.IsPowerUnlocked)
            {
                unlockedPowerDataList.Add(powerData);
                InitUnlockedPowerManager(powerData);
            }
        }
    }

    void Load()
    {
        string powerDataPath = GetPath();

        try
        {
            using (StreamReader file = File.OpenText(powerDataPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var jObject = (JArray)JToken.ReadFrom(reader);
                var jsonString = jObject.ToString(Newtonsoft.Json.Formatting.None);

                powerDataList = JsonConvert.DeserializeObject<List<PowerData>>(jsonString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    void UnlockPower(string powerName)
    {
        foreach (var powerData in powerDataList)
        {
            if (powerName == powerData.PowerName)
            {
                powerData.IsPowerUnlocked = true;

                unlockedPowerDataList.Add(powerData);
                InitUnlockedPowerManager(powerData);
            }
        }
    }
}
