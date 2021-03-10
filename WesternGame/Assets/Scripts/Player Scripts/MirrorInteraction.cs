using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MirrorInteraction : MonoBehaviour
{
    public GameObject mirror;
    public Text endGameText;
    
    void Start()
    {
        SpawnMirror();
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
            Win();
        }
    }

    void Win()
    {
        SceneManager.LoadScene(4);
    }
}
