using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] private ClawController claw;

    public void ResetGame()
    {
        UnpauseGame();
        GameStateManager.GameIsOver = false;




        if(ClawController.isGrabbing)
        {
            claw.ResetRotation();
        }

        SceneManager.LoadScene(0);

        

    }

    public void StopGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }



}
