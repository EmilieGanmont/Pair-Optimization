using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayerController : MonoBehaviour
{
    private PlayerControls playercontrols;
    private InputAction movement;

    [SerializeField] private float movementSpeed = 1f;

    private Rigidbody2D rg2d;

    private void Awake()
    {
        playercontrols = new PlayerControls();
        rg2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        movement = playercontrols.PlayerMovement.Movement;
        movement.Enable();
    }

    private void FixedUpdate()
    {
        rg2d.velocity = movement.ReadValue<Vector2>() * movementSpeed;
    }
}
