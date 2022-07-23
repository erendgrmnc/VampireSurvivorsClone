using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : Power, IPower
{
    private Vector3 playerPosition;

    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (powerPrefab == null)
        {
            Destroy(gameObject);
        }

        if (isTimeDestroyable)
        {
            StartCoroutine("DestroyInstance");
        }
    }

    public void Attack()
    {
        SpawnPowerObject(playerPosition);
    }

    public IEnumerator DestroyInstance()
    {
        yield return new WaitForSeconds(destroyTime);
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}