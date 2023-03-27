using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;

    //[SerializeField] private ClawController claw;

    private void Start()
    {
        isPaused = false;
    }

    public void ResetGame()
    {
       SceneManager.LoadScene(0);
       UnpauseGame();
       //GameStateManager.GameIsOver = false;



    
  // if(ClawController.isGrabbing)
  // {
  //     claw.ResetRotation();
  // }


        

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
