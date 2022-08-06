using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AxeThrow : Power
{
    private Rigidbody2D physics;

    void Awake()
    {
        PowerType = PowerType.AxeThrow;
        physics = GetComponent<Rigidbody2D>();
    }
    
    void OnEnable()
    {
        AddForce();
    }

    void AddForce()
    {
        int playerLastXDirection = Player.Instance.GetPlayerLastDirection();

        var forceVector = new Vector2(50 * playerLastXDirection, 500);
        physics.AddForce(forceVector);
    }

    public override IEnumerator DestroyInstance()
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

            if (isDestroyableOnHit)
            {
                gameObject.SetActive(false);
            }
        }
    }
}