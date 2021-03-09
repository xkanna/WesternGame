using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public Text numberOfBulletsText;
    private int numberOfBullets;

    private void Start()
    {
        numberOfBullets = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        numberOfBullets++;
        numberOfBulletsText.text = numberOfBullets.ToString();
        Instantiate(bullet, firepoint.position, firepoint.rotation);

    }
}
