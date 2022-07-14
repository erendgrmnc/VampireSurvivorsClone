using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectile;
    public int amountToPool = 4;
    List<GameObject> projectilePool;
    GameObject projectilePoolObject;

    protected void InitPool()
    {
        projectilePoolObject = new GameObject();
        projectilePool = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            var projectileObject = CreateAndGetPoolObject();
            projectilePool.Add(projectileObject);
        }
    }

    virtual public GameObject GetPoolObject()
    {
        foreach (var poolObject in projectilePool)
        {
            if (!poolObject.activeInHierarchy)
            {
                poolObject.GetComponent<Projectile>().SpawnProjectile();
                return poolObject;
            }
        }

        var newPoolObj = CreateAndGetPoolObject();
        newPoolObj.GetComponent<Projectile>().SpawnProjectile();
        return newPoolObj;
    }

    protected GameObject CreateAndGetPoolObject()
    {
        var poolObject = Instantiate(projectile);
        poolObject.SetActive(false);
        poolObject.transform.parent = projectilePoolObject.transform;
        return poolObject;
    }

}
