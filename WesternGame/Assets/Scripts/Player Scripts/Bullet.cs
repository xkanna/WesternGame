using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
      
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(50);
            Destroy(gameObject);
        }

        ShootingEnemy shootingEnemy = hitInfo.GetComponent<ShootingEnemy>();
        if(shootingEnemy != null)
        {
            shootingEnemy.TakeDamage(50);
            Destroy(gameObject);
        }
    } 
}
