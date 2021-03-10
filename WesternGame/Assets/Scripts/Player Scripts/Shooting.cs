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
    public AudioSource source;

    private void Start()
    {
        numberOfBullets = 20;
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
        numberOfBullets--;
        if (numberOfBullets > 0)
        {
            numberOfBulletsText.text = numberOfBullets.ToString();
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            source.Play();
        }

    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Ammo")
        {
            AddAmmo();
            Ammo ammo = hitInfo.GetComponent<Ammo>();
            if (ammo != null)
            {
                ammo.DestroyAmmo();

            }
        }
    }

    public void AddAmmo()
    {
        numberOfBullets = numberOfBullets + 20;
        numberOfBulletsText.text = numberOfBullets.ToString();
    }

}
