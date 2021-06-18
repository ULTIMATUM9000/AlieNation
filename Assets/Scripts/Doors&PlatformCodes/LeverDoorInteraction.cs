using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorInteraction : MonoBehaviour
{
    public GameObject Door;
    public Sprite crankDown;

    public void Start()
    {
       
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManagerScript>().Play("DoorBridge");
            Door.SetActive(false);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = crankDown;
        }
    }


}
