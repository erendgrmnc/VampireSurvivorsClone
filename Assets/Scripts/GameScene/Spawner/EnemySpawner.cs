using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public float enemySpawnInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        InitPool("Enemy");
        StartCoroutine(SpawnEnemies(enemySpawnInterval, objectOfPool));
    }

    public virtual IEnumerator SpawnEnemies(float interval, GameObject enemyToSpawn)
    {
        yield return new WaitForSeconds(interval);

        var spawnPosition = new Vector3(transform.position.x, Random.Range(-11, 7));

        SpawnObject(spawnPosition);

        StartCoroutine(SpawnEnemies(interval, enemyToSpawn));
    }
}
