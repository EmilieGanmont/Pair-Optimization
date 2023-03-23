using UnityEngine.InputSystem;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    private PlayerControls playercontrols;

    [SerializeField] private float distance = 0f;
    [SerializeField] private Transform holdpoint;


    private bool isGrabbing; 

    private LayerMask Pickup;
    private Transform currentObject; 



    private void Awake()
    {
        playercontrols = new PlayerControls();
    }

    void Update()
    {
        if(currentObject)
        {
            currentObject.position = holdpoint.position;
            currentObject.rotation = holdpoint.rotation;
        }
    }


    private void OnEnable()
    {
        playercontrols.PlayerMovement.Shoot.performed += Shoot;
        playercontrols.PlayerMovement.Shoot.Enable();
    }

    private void Shoot(InputAction.CallbackContext obj)
    {

        Debug.Log("Shoot!");
        if (!currentObject)
        {
           Debug.Log("Nothing");
           Collider2D clawGrab = Physics2D.OverlapCircle(transform.position, distance, Pickup);
     
            if(clawGrab)
            {
                currentObject = clawGrab.transform;

                Debug.Log("Got item!");
            }
        }
        else
        {
            currentObject = null;
            Debug.Log("No item!");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            currentObject = collision.transform;
        }
    }
}
