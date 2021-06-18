using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float speed = 10;
    public float fireRate = 0.25f;
    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Time.time > nextFire)
        {
            FindObjectOfType<AudioManagerScript>().Play("BulletShoot");
            nextFire = Time.time + fireRate;
            Instantiate(bullet, spawnPoint.position, Quaternion.identity);
        }
    }
}




