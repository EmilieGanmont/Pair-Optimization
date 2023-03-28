using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayerController : MonoBehaviour
{
    private PlayerControls playercontrols;
    [SerializeField] private PauseManager pauseManager;

    private InputAction movement;
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody2D rg2d;

    [SerializeField] private SpriteRenderer sprite;
    private bool facingRight;


    [SerializeField] private AudioClip hoverSFX;
    private AudioSource audioSource;


    private void Awake()
    {
        playercontrols = new PlayerControls();
        rg2d = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        facingRight = true;
    }

    private void OnEnable()
    {
        movement = playercontrols.PlayerMovement.Movement;
        movement.Enable();

        playercontrols.PlayerMovement.Pause.performed += PauseGame;
        playercontrols.PlayerMovement.Pause.Enable();

    }


    private void PauseGame(InputAction.CallbackContext obj)
    {
        pauseManager.PauseGame();
    }

    private void FixedUpdate()
    {
        rg2d.velocity = movement.ReadValue<Vector2>() * movementSpeed;

        if (movement.ReadValue<Vector2>().x > 0f && !facingRight)
        {
            sprite.flipX = false;
            facingRight = true;
        }
        else if (movement.ReadValue<Vector2>().x < 0f && facingRight)
        {
            sprite.flipX = true;
            facingRight = false;
        }

        if ((rg2d.velocity.x != 0 || rg2d.velocity.y != 0))
        {
            if(!audioSource.isPlaying && Time.timeScale != 0)
            {
                audioSource.PlayOneShot(hoverSFX);
            }
  
        }
        else
        {
            audioSource.Stop();
        }

    }
}
