using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 2f;
    public float damage = 50f;

    virtual protected void Update()
    {
        Move();
    }

    virtual protected IEnumerator InvokeDestroyProjectile()
    {
        yield return new WaitForSeconds(lifeTime);
        DestroyProjectile();
    }

    virtual public void SpawnProjectile()
    {
        gameObject.SetActive(true);
        StartCoroutine(InvokeDestroyProjectile());
    }

    virtual protected void Move()
    {

        if (gameObject.activeSelf)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }

    virtual protected void DestroyProjectile()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
