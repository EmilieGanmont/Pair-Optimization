using UnityEngine;

public class Toy : MonoBehaviour
{
    public GameObject scoreManager;
    private Score score;

    [SerializeField] private int points;
    [SerializeField] private bool isCoin;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer; 


    private ToyObjectPool toyOB = new ToyObjectPool();


    private void Start()
    {
        score = FindObjectOfType<Score>();

        for(int i = 0; i < sprites.Length; i++)
        {

            int randSprite = Random.RandomRange(0, sprites.Length);

            spriteRenderer.sprite = sprites[randSprite];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            score.changeScore(points);
            this.gameObject.SetActive(false);
        }

    }

}
