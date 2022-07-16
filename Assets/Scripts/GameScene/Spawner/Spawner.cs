using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int amountToPool = 20;
    public GameObject objectOfPool;
    List<GameObject> spawnableObjects;
    GameObject objectGroup;
    private string objectGroupName = "";

    protected void InitPool(string objectGroupName)
    {
        this.objectGroupName = objectGroupName;
        objectGroup = new GameObject(objectGroupName);
        spawnableObjects = new List<GameObject>();
        GameObject tmpObject;
        for (int i = 0; i < amountToPool; i++)
        {
            tmpObject = Instantiate(objectOfPool);
            tmpObject.SetActive(false);
            tmpObject.transform.parent = objectGroup.transform;
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
        newPoolObject.transform.parent = objectGroup.transform;
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
