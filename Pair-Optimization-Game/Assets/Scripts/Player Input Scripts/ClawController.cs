using UnityEngine.InputSystem;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    private PlayerControls playercontrols;

    [SerializeField] private float distance = 0f;
    [SerializeField] private Transform holdpoint;

    [SerializeField] private Transform LeftClaw;

    [SerializeField] private Transform RightClaw;

    [SerializeField] private float leftRotate, rightRotate; 


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
        if (!isGrabbing)
        {
            LeftClaw.transform.Rotate(0f, 0f, leftRotate);
            RightClaw.transform.Rotate(0f, 0f, rightRotate);
            isGrabbing = true;
        }
        else
        {
            LeftClaw.transform.Rotate(0f, 0f, -leftRotate);
            RightClaw.transform.Rotate(0f, 0f, -rightRotate);
            isGrabbing = false;
        }
    }

}
