using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 1f;

    public float speed = 5f;

    Player player;

    bool canMove;

    protected virtual void Init()
    {
        canMove = true;
        player = Player.Instance;
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Hit !");
        }

        else if (collision.tag == "Enemy")
        {
            canMove = false;
        }

        else if (collision.tag == "Weapon")
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            canMove = true;
        }
    }

}
