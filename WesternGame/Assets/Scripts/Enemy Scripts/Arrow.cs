using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 0.5f;
    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
        Flip();
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BasicMovement enemy = collision.GetComponent<BasicMovement>();
            if (enemy != null)
            {
                enemy.TakeDamage(50);
                DestroyProjectile();
            }
        }
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
