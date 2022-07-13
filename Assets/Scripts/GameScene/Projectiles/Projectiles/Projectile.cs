using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 2f;
    float passedTimeSinceOnScene = 0f;

    virtual protected void Start()
    {
        InvokeRepeating("IncreasePassedTime", 1f, 1f);
    }

    virtual protected void Update()
    {
        CheckIsObjectDestroyable();
        Move();
    }

    virtual protected void IncreasePassedTime()
    {
        if (gameObject.activeSelf)
        {
            passedTimeSinceOnScene++;
        }
    }

    virtual protected void Move()
    {

        if (gameObject.activeSelf)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }

    virtual protected void CheckIsObjectDestroyable()
    {
        if (gameObject.activeSelf)
        {
            if (passedTimeSinceOnScene == lifeTime)
            {
                gameObject.SetActive(false);
                passedTimeSinceOnScene = 0f;
            }
        }
    }
}
