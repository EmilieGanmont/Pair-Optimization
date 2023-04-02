using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassChanger : MonoBehaviour
{    
    public Rigidbody2D rb;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.mass = 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndArea")
        {
            rb.mass = 500;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndArea")
        {
            rb.mass = 1;
        }
    }
}
