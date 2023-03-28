using UnityEngine;
using System;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{

    public int lives;
    [SerializeField]private int startLives = 5;

    ClawController clawControler = new ClawController(); 


    //Time

    [SerializeField] private float startTime;
    [HideInInspector]public float timeRemaining;
    private float seconds;

    [HideInInspector] public bool timeIsRunning = false; 

    public event EventHandler TimeRanOut;



    [SerializeField] private Text timerText;
    [SerializeField] private Text livesText;
    [SerializeField] private static Text _livesText;


    [SerializeField] private GameObject gameOverUI;

    public static bool GameIsOver;


    [SerializeField] private PauseManager pauseManager; 

    private void Start()
    {
        GameIsOver = false;
        lives = startLives;

        timeRemaining = startTime;
        timerText.text = $"Time: {timeRemaining}";


        _livesText = livesText; 

        _livesText.text = $"Plays: {lives}";
    }

    private void Update()
    {
        if(timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                TimeRanOut?.Invoke(this, EventArgs.Empty);

                changeLives(-1);

                if(lives < 0)
                {
                    timeRemaining = 0;
                }
                else
                {
                    timeRemaining = startTime;
                }

                timerText.text = $"Time: {timeRemaining}";

            }

            if (GameIsOver == false)
            {
                gameOverUI.SetActive(false);
            }
        }


        if (lives <= 0 && timeRemaining <= 0)
        {
                GameOver();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = $"Time: {seconds}";
    }

    public void ResetTime() => timeRemaining = startTime; 

    public void changeLives(int amount)
    {
        lives += amount;

        if (lives < 0)
        {
            lives = 0;
        }
        _livesText.text = $"Plays: {lives}";

    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        pauseManager.StopGame();
        GameIsOver = true;
        lives = startLives;
    }
}
