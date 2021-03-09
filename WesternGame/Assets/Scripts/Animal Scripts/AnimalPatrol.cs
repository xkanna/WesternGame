using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPatrol : MonoBehaviour
{

    public float speed = 1f;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private float waitTime;
    public float startWaitTime;

    public bool sadled = false;
    public float sadledX;
    public float speedTimeLeft = 5;

    void Start()
    {
        waitTime = startWaitTime;
        minX = moveSpot.localPosition.x;
        maxX = moveSpot.localPosition.x + 3;
        minY = moveSpot.localPosition.y;
        maxY = moveSpot.localPosition.y + 3;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!sadled)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.localPosition, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    Flip();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            StartTimer();
            FlipHorse();
        }
    }

    void Flip()
    {
        Vector3 characterScale = transform.localScale;

        if ((moveSpot.position.x - transform.position.x) > 0)
        {
            characterScale.x = -1;
        }
        else if ((moveSpot.position.x - transform.position.x) < 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }

    void FlipHorse()
    {
        Vector3 characterScale = transform.localScale;

        if (sadledX < transform.position.x)
        {
            characterScale.x = -1;
        }
        else if (sadledX > transform.position.x)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
        sadledX = transform.position.x;
    }

    public void StartTimer()
    {
        speedTimeLeft -= Time.deltaTime;
        if (speedTimeLeft < 0)
        {
            sadled = false;
            Destroy(gameObject);
            speedTimeLeft = 7;
        }
    }
}
