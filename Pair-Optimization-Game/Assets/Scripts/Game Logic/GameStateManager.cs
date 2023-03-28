using UnityEngine;
using System;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{

    //This script controls the amount of lives and time in game. It controls the game over state. 

    public int lives;
    [SerializeField] private int startLives = 5;

    //Time
    [SerializeField] private float startTime;
    [HideInInspector] public float timeRemaining;
    private float seconds;
    [HideInInspector] public bool timeIsRunning = true;
    public event EventHandler TimeRanOut;


    //Points
    [SerializeField] private Text timerText;
    [SerializeField] private Text livesText;
    [SerializeField] private static Text _livesText;


    [SerializeField] private GameObject gameOverUI;
    public static bool GameIsOver;


    [SerializeField] private PauseManager pauseManager;

    [SerializeField] private Animator livesAnimator;

    private void Start()
    {
        GameIsOver = false;
        lives = startLives;

        timeRemaining = startTime;
        timerText.text = $"Time: {timeRemaining}";


        _livesText = livesText;
        _livesText.text = $"Grabs: {lives}";
    }

    private void Update()
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

            if (lives < 0)
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

        if (lives <= 1)
        {
            livesAnimator.SetBool("IsLowLife", true);
        }

        else
        {
            livesAnimator.SetBool("IsLowLife", false);
        }

        _livesText.text = $"Grabs: {lives}";

    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        pauseManager.StopGame();
        GameIsOver = true;
        lives = startLives;
    }
}
