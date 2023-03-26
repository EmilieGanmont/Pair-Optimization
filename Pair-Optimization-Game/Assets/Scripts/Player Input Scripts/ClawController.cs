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


    public static bool isGrabbing; 

    private void Awake()
    {
        playercontrols = new PlayerControls();

        defaultLeftRotation = LeftClawTransform; 


        LeftClawTransform = LeftClaw;
        RightClawTransform = RightClaw;
    }

    private void Start()
    {
        Debug.Log(LeftClawTransform.rotation);
        gameStateManager = FindObjectOfType<GameStateManager>();

        if(gameStateManager != null)
        {
            gameStateManager.TimeRanOut += TimePunishment;
        }
        isGrabbing = false;

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


       // if (!PauseManager.isPaused)
        {
            if (!isGrabbing)
            {
                LeftClawTransform.transform.Rotate(0f, 0f, leftRotate);
                RightClawTransform.transform.Rotate(0f, 0f, rightRotate);
                isGrabbing = true;


                Debug.Log(isGrabbing);
            }
            else
            {
                LetGo();

                Debug.Log(isGrabbing);
            }
        }

    }

    public void LetGo()
    {
        if(isGrabbing)
        {
                LeftClawTransform.transform.Rotate(0f, 0f, -leftRotate);
                RightClawTransform.transform.Rotate(0f, 0f, -rightRotate);
                isGrabbing = false;

            if (gameStateManager != null)
            {
                gameStateManager.changeLives(-1);
            }

        }
    }


    public void ResetRotation()
    {
        LeftClawTransform = defaultLeftRotation;
    }

}
