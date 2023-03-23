using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    static public int highScore = 0;


    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text highScoreTxt;




    private void Start()
    {
        scoreTxt.text = $"Score: {score}";
        highScoreTxt.text = $"Highscore: {highScore}";

       
    }

    public void changeScore(int value)
    {
        score += value;
        scoreTxt.text = $"Score: {score}";


        if (score >= highScore)
        {
            highScore = score;
             highScoreTxt.text = $"Highscore: {highScore}";
        }
    }


}
