using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class PowerData
{
    [SerializeField] 
    public string PowerName { get; set; }
    [SerializeField]
    public bool IsPowerUnlocked { get; set; }
    [SerializeField]
    public bool IsPowerNeedsPooling { get; set; }
    [SerializeField]
    public int PoolStartAmount { get; set; }

    public PowerManager PowerManager { get; set; }
}