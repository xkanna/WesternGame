using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float health = 200;
    public Text healthText;
    public float speed = 2f;
    public bool speededUp = false;
    public float speedTimeLeft = 5;
    public float timeLeft = 80;
    public Text timeLeftText;
    public Text endGametext;

    void Start()
    {
        timeLeftText.text = "0";
        healthText.text = health.ToString();
    }

    void Update()
    {
        Move();
       
        if (speededUp)
        {
            SpeedTimer();
        }

        GameTimer();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    public void Die()
    {
        Destroy(gameObject);
        endGametext.text = "DEFEAT";
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.tag == "Horse")
        {
            
            hitInfo.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            hitInfo.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            AnimalPatrol horse = hitInfo.GetComponent<AnimalPatrol>();
            if (horse != null)
            {
                horse.sadled = true;
                horse.sadledX = transform.position.x;
                SpeedUp();
            }
        }
        else if (hitInfo.gameObject.tag == "Snake")
        {
            Die();
        }
        else if (hitInfo.gameObject.tag == "Hole")
        {
            Die();
        }
    }

    void SpeedUp()
    {
        speed = 4f;
        speededUp = true;
    }

    void SpeedTimer()
    {
        speedTimeLeft -= Time.deltaTime;
        
        if (speedTimeLeft < 0)
        {
            speededUp = false;
            speedTimeLeft = 5;
            speed = 2f;
        }
    }

    void GameTimer()
    {
        timeLeft -= Time.deltaTime;
        timeLeftText.text = timeLeft.ToString("0.00");
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthText.text = health.ToString();
        if (health <= 0)
        {
            Die();
        }
    }
}
