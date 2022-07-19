using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : MonoBehaviour
{
    public GameObject powerPrefab;
    public float damage = 10f;
    public bool isTimeDestroyable = false;
    public float destroyTime = 5f;
}
