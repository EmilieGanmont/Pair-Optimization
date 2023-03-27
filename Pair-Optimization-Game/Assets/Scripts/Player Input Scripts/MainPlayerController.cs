using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayerController : MonoBehaviour
{
    private PlayerControls playercontrols;
    private InputAction movement;

    [SerializeField] private float movementSpeed = 1f;

    [SerializeField] private SpriteRenderer sprite; 

    private Rigidbody2D rg2d;

    private bool facingRight;

    private void Awake()
    {
        playercontrols = new PlayerControls();
        rg2d = GetComponent<Rigidbody2D>();
        facingRight = true; 
    }

    private void OnEnable()
    {
        movement = playercontrols.PlayerMovement.Movement;
        movement.Enable();
    }

    private void FixedUpdate()
    {
        rg2d.velocity = movement.ReadValue<Vector2>() * movementSpeed;

        if(movement.ReadValue<Vector2>().x > 0f && !facingRight)
        {
            sprite.flipX = false;
            facingRight = true;
            Debug.Log("Moveing Right");
        }
        else if(movement.ReadValue<Vector2>().x < 0f && facingRight)
        {
            sprite.flipX = true;
            facingRight = false;
            Debug.Log("Moveing Left");
        }
    }

    void Flip()
    {

    }
}
