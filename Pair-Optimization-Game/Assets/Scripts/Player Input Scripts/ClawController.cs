using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class ClawController : MonoBehaviour
{
    private PlayerControls playercontrols;


    [SerializeField] private Transform LeftClaw;
    [SerializeField] private Transform RightClaw;


    private static Transform LeftClawTransform;
    private static Transform RightClawTransform;

    private static Transform defaultLeftRotation;

    [SerializeField] private float leftRotate, rightRotate;

    GameStateManager gameStateManager;


    public  bool isGrabbing;

    private void Awake()
    {
        playercontrols = new PlayerControls();

        defaultLeftRotation = LeftClawTransform;


        LeftClawTransform = LeftClaw;
        RightClawTransform = RightClaw;

    }

    private void Start()
    {
                isGrabbing = false;
        Debug.Log(LeftClawTransform.rotation);
        gameStateManager = FindObjectOfType<GameStateManager>();

        if (gameStateManager != null)
        {
            gameStateManager.TimeRanOut += TimePunishment;
        }


    }

    private void TimePunishment(object sender, EventArgs e)
    {
        LetGo();
    }

    private void OnEnable()
    {
        playercontrols.PlayerMovement.Shoot.performed += Shoot;
        playercontrols.PlayerMovement.Shoot.Enable();
    }


    private void Shoot(InputAction.CallbackContext obj)
    {

        //if (!PauseManager.isPaused)
        {
            if(LeftClaw != null && RightClaw != null)
            {
                if (isGrabbing)
                {
                    LetGo();
                    return;
                    //
                    //
                    //
                    //
                    //Debug.Log(LeftClawTransform.rotation);
                    //Debug.Log(isGrabbing);
                }
                else
                {

                    LeftClaw.transform.Rotate(0f, 0f, leftRotate);
                    RightClaw.transform.Rotate(0f, 0f, rightRotate);
                    isGrabbing = true;
                    return;
                }
            }

        }

    }

    public void LetGo()
    {
       
       
            LeftClaw.transform.Rotate(0f, 0f, -leftRotate);
            RightClaw.transform.Rotate(0f, 0f, -rightRotate);
            isGrabbing = false;

        if (gameStateManager != null)
            {
                gameStateManager.changeLives(-1);
            }
        
    }


    public void ResetRotation()
    {
        LeftClawTransform = defaultLeftRotation;
    }

}
