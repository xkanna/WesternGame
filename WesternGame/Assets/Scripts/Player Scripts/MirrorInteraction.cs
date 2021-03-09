﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorInteraction : MonoBehaviour
{
    public GameObject mirror;
    public Text endGameText;
    
    void Start()
    {
        SpawnMirror();
    }
    
    void Update()
    {
        
    }


    void SpawnMirror()
    {
        float spawnX = Random.Range(20, -12);
        float spawnY = Random.Range(-22, 32);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(mirror, spawnPosition, Quaternion.identity);

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag == "Mirror")
        {
            
        }
    }

    void Win()
    {
        endGameText.text = "WIN!";
    }
}