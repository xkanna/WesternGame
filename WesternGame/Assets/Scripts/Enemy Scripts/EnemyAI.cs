using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    
    public float speed = 1f;
    private float maximumDistance = 0.3f;
    private float minimumDistance = 5f;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > maximumDistance && Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);

        BasicMovement player = hitInfo.GetComponent<BasicMovement>();
        if (player != null)
        {
            player.Die();
        }
    }

}
