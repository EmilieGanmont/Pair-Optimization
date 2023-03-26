using UnityEngine;
using System;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{

    public int lives;
    [SerializeField]private int startLives = 5;


    //Time

    [SerializeField] private float startTime;
    [HideInInspector]public float timeRemaining;
    private float seconds;

    public event EventHandler TimeRanOut;



    [SerializeField] private Text timerText;
    [SerializeField] private Text livesText;
    [SerializeField] private static Text _livesText;


    [SerializeField] private GameObject gameOverUI;

    public static bool GameIsOver;


    [SerializeField] private PauseManager pauseManager; 

    private void Start()
    {
        lives = startLives;

        timeRemaining = startTime;
        timerText.text = $"Time: none idiot";


        _livesText = livesText; 

        _livesText.text = $"Plays: {lives}";


    }

    private void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            TimeRanOut?.Invoke(this, EventArgs.Empty);
            changeLives(-1);
            timerText.text = $"Time: {timeRemaining}";
            timeRemaining = startTime;
        }

        if(GameIsOver == false)
        {
            gameOverUI.SetActive(false);
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
        _livesText.text = $"Plays: {lives}";

        if (lives <= 0)
        {
           GameOver(); 
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        pauseManager.StopGame();
        GameIsOver = true;
        lives = startLives;
    }
}
