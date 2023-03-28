using UnityEngine;

public class Toy : MonoBehaviour
{
    public GameObject scoreManager;
    private Score score;

    [SerializeField] private int points;
    [SerializeField] private bool isCoin;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer; 


    private void Start()
    {
        score = FindObjectOfType<Score>();

        int randSprite = Random.Range(0, sprites.Length); //Randomizes sprite 
        spriteRenderer.sprite = sprites[randSprite];
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            score.changeScore(points);
            this.gameObject.SetActive(false); //Returns toy to object pool

        }

    }

}
