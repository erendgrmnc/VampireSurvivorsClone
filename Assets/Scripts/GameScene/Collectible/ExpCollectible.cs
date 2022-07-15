using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollectible : MonoBehaviour, ICollectible
{
    public float xpAmount = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnCollectibleCollected();
        }
    }

    public void OnCollectibleCollected()
    {
        //TODO: Add XP amount to player xp.

    }

    public void InitCollectible()
    {
        gameObject.SetActive(true);
    }

    public void SpawnCollectible()
    {
        gameObject.SetActive(true);
    }

    public void DestroyCollectible()
    {
        gameObject.SetActive(false);
    }
}
