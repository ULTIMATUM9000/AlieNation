using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorsBridgeInteraction : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Bridge;
    public Sprite crankDown;

    public void Start()
    {
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Door1.SetActive(false);
            Door2.SetActive(false);
            Bridge.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = crankDown;
        }
    }
}
