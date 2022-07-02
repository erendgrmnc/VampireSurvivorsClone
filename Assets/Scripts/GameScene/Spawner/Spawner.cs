using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int amountToPool = 20;
    public GameObject objectOfPool;
    List<GameObject> spawnableObjects;

    protected void InitPool()
    {
        spawnableObjects = new List<GameObject>();
        GameObject tmpObject;
        for (int i = 0; i < amountToPool; i++)
        {
            tmpObject = Instantiate(objectOfPool);
            tmpObject.SetActive(false);
            spawnableObjects.Add(tmpObject);
        }
    }

    protected GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!spawnableObjects[i].activeInHierarchy)
            {
                return spawnableObjects[i];
            }
        }

        GameObject newPoolObject = Instantiate(objectOfPool);
        newPoolObject.SetActive(false);
        spawnableObjects.Add(newPoolObject);
        return newPoolObject;
    }

    protected virtual void SpawnObject(Vector3 spawnPosition)
    {
        GameObject objectToSpawn = GetPooledObject();
        if (objectToSpawn != null)
        {
            objectToSpawn.transform.position = spawnPosition;
            objectToSpawn.transform.rotation = transform.rotation;
            objectToSpawn.SetActive(true);
        }
    }

}
