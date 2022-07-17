using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollectible : MonoBehaviour, ICollectible
{
    public float xpAmount = 10f;
    PlayerExpManager playerExpManager;

    void Start()
    {
        playerExpManager = GameObject.FindGameObjectWithTag("PlayerExpManager").GetComponent<PlayerExpManager>();
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
        playerExpManager.AddExpToPlayer(xpAmount);
        DestroyCollectible();
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
