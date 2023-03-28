using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] ParticleSystem confettiVFX;

    private AudioSource audioSource;
    [SerializeField] private AudioClip gotItemSFX; 


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            confettiVFX.Play();
            audioSource.PlayOneShot(gotItemSFX);
        }

    }

}
