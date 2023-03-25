using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject scoreManager;
    private Score score;

    [SerializeField] private int points;


    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            score.changeScore(points);
            GameStateManager.changeLives(1);
            this.gameObject.SetActive(false);
        }

    }
}

