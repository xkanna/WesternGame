using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public int health = 200;
    public float speed = 1f;
    public float stoppingDistance = 6f;
    public float retreatDistance = 3f;

    public GameObject arrow;
    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots = 2;
    public bool shooting = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        CheckDistance();
        CheckTimeBTWShots();
        Flip();
    }

    void CheckDistance()
    {
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            shooting = true;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {
            transform.position = this.transform.position;
            shooting = false;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance && Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            shooting = true;
        }
        else
        {
            shooting = false;
        }
    }

    void CheckTimeBTWShots()
    {

        if (timeBtwShots <= 0 && shooting)
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Flip()
    {
        Vector3 characterScale = transform.localScale;

        if ((player.position.x - transform.position.x) > 0)
        {
            characterScale.x = -1;
        }
        else if ((player.position.x - transform.position.x) < 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}
