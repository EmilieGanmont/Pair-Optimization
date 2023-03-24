using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject scoreManager;
    private Score score;

    [SerializeField] private int points;

    private ToyObjectPool toyOB = new ToyObjectPool();


    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            score.changeScore(points);
            this.gameObject.SetActive(false);
        }

    }
}

