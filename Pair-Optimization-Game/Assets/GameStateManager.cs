using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public static int lives;
    public int startLives;

    public void changeLives(int amount)
    {
        lives += amount; 

        if(lives <= 0)
        {
           GameOver(); 
        }
    }

    public void GameOver()
    {
        lives = startLives; 
        
    }
}
