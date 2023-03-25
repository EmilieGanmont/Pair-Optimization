using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused;

    [SerializeField] private ClawController claw;

    public void ResetGame()
    {
        UnpauseGame();
        GameStateManager.GameIsOver = false;

        claw.ResetRotation();

        SceneManager.LoadScene(0);

        

    }

    public static void StopGame()
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
