using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public float health = 200;
    public float speed = 2f;
    public bool speededUp = false;
    public float speedTimeLeft = 5;
    public float timeLeft = 80;
    public Text scoreText;

    void Start()
    {
        scoreText.text = "0";
    }

    void Update()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime * speed;

        if (speededUp)
        {
            SpeedTimer();
        }

        GameTimer();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.tag == "Horse")
        {
            //Set the parent of that object to the platform
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
            speed = 2f;
        }
    }

    void GameTimer()
    {
        timeLeft -= Time.deltaTime;
        scoreText.text = timeLeft.ToString();
        if (timeLeft < 0)
        {
            Destroy(gameObject);
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
}
