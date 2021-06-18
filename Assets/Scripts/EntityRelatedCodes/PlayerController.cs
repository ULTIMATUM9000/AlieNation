using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//JUST A PLACEHOLDER PLAYER THAT I USED

public class PlayerController : MonoBehaviour
{  
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        { }
        else if (Input.GetKey(KeyCode.W))
        {
            Move(0, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(0, -speed);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        { }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(speed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(-speed, 0);
        }

       
    }


    private void Move(float speedX, float speedY)
    {
        transform.position = new Vector2(transform.position.x + (speedX * Time.deltaTime), transform.position.y + (speedY * Time.deltaTime));
    }




   
}
