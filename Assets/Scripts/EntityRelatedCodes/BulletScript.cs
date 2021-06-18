using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float damage = 10.0f;
    private Rigidbody2D Rigid2D;

    //public Transform playerPosition;
    
    float timer1 = 0.0f;
    bool isFacingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        Rigid2D = this.GetComponent<Rigidbody2D>();
        //playerPosition = null;
    }

    void OnEnable()
    {
        isFacingRight = GameObject.Find("Player").GetComponent<PlayerMovement>().facingRight;
    }

    void Update()
    {
        timer1 += Time.deltaTime;
        if(timer1 >= 3.0f)
        {
            Disable();
            timer1 = 0.0f;
        }
         
        ShootDirection();
        //if (PlayerMovement.facingRight == true)
        //{
        //Debug.Log("Right");
        //    transform.position += transform.right * speed * Time.deltaTime;
        //}
        //if (PlayerMovement.facingRight == false)
        //    {
        //        transform.position -= transform.right * speed * Time.deltaTime;
        //    }
    }

    void ShootDirection()
    {
        if (isFacingRight)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (!isFacingRight)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    public void Disable()
    {
        this.gameObject.SetActive(false); //
        //playerPosition = null;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.GetComponent<Enemy>() != null)
        {
            Enemy enemy = other.collider.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if(other.collider.GetComponent<DebrisScript>() != null)
        {
            DebrisScript debris = other.collider.GetComponent<DebrisScript>();
            debris.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            this.gameObject.SetActive(false);
        }
    }

}
