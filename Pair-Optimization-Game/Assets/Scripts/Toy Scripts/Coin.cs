using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameStateManager gameStateManager;
    private Score score;

    [SerializeField] private int points;


    private void Start()
    {
        score = FindObjectOfType<Score>();
        gameStateManager = FindObjectOfType<GameStateManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            score.changeScore(points);
            gameStateManager.changeLives(1);
            gameStateManager.ResetTime();

            this.gameObject.SetActive(false); //Returns coin to object pool
        }

    }
}

