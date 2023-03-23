using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject scoreManager;

    private Score s;


    private void Start()
    {
        s = scoreManager.GetComponent<Score>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            s.changeScore(1);
            Debug.Log("Got Toy");
        }

    }
}
