using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class PowerData : MonoBehaviour
{
    [SerializeField]
    private Power PowerObject { get; set; }

    public bool IsPowerUnlocked { get; private set; }
    [SerializeField]
    private bool isPowerNeedsPooling;
    [SerializeField]
    [HideInInspector] 
    private int poolStartAmount;
    
    void OnInspectorGUI()
    {
        isPowerNeedsPooling = GUILayout.Toggle(isPowerNeedsPooling, "IsPowerNeedsPooling");

        if (isPowerNeedsPooling)
            poolStartAmount = EditorGUILayout.IntSlider("PoolStartAmount:", poolStartAmount, 1, 100);
    }

    public void UnlockPower()
    {
        if (!IsPowerUnlocked)
        {
            IsPowerUnlocked = true;
        }
    }
}