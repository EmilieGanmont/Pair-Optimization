using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); 
    }
}
