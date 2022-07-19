using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : Power, IPower
{
    void Start()
    {
        if (powerPrefab == null)
        {
            Destroy(gameObject);
        }

        if (isTimeDestroyable)
        {
            StartCoroutine("DestroyInstance");
        }
    }

    void Update()
    {
        
    }

    public void Attack()
    {

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
