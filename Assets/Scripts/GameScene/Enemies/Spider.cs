using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    protected override void CheckIsDestroyed()
    {
        base.CheckIsDestroyed();
        if (hp <= 0)
        {
            var collectible = GameObject.FindGameObjectWithTag("CollectibleSpawner").GetComponent<CollectibleSpawner>().GetCollectible();
            collectible.GetComponent<ExpCollectible>().SpawnCollectible();
            collectible.transform.position = gameObject.transform.position;
        }
    }
}
