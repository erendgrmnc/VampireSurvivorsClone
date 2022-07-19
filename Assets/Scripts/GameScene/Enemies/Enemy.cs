using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float damage = 10f;

    public float speed = 5f;

    public float hp = 100f;

    Player player;
    PlayerHealthManager playerHealthManager;

    bool canMove;

    protected virtual void Init()
    {
        canMove = true;
        player = Player.Instance;
        InitPlayerHealthManager();
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
            playerHealthManager.DamagePlayer(damage);
            Debug.Log("Hit !");
        }

        else if (collision.tag == "Enemy")
        {
            canMove = false;
        }

        else if (collision.tag == "Weapon")
        {
            float projectileDamage = collision.gameObject.GetComponent<Projectile>().damage;
            TakeDamage(projectileDamage);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        hp -= damage;
        CheckIsDestroyed();
    }

    protected virtual void CheckIsDestroyed()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            canMove = false;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            canMove = true;
        }
    }

    void InitPlayerHealthManager()
    {
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerHealthManager>();
    }

}
