using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : Spawner
{
    // Start is called before the first frame update
    void Start()
    {
        InitPool("Collectible");
    }

    public GameObject GetCollectible()
    {
        return GetPooledObject();
    }
}
