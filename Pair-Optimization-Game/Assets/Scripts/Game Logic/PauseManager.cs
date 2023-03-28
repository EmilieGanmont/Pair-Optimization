using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    //This script controls anytime the game needs to be stopped, including gameovers. Also includes reseting and quiting the game. 

    public static bool isPaused;
    [SerializeField] private GameObject pauseUI;

    private void Start()
    {
        isPaused = false;
    }

    public void ResetGame()
    {
       SceneManager.LoadScene("Game");
       UnpauseGame();
       GameStateManager.GameIsOver = false;
    }

    public void PauseGame()
    {
        if (!GameStateManager.GameIsOver)
        {
            if (isPaused)
            {
                UnpauseGame();
                pauseUI?.SetActive(false);
            }
            else
            {
                pauseUI?.SetActive(true);
                StopGame();
            }
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }



}
