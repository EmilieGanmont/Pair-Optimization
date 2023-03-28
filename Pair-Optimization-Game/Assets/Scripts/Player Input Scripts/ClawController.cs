using UnityEngine.InputSystem;
using UnityEngine;
using System;
using System.Collections;

public class ClawController : MonoBehaviour
{
    private PlayerControls playercontrols;


    [SerializeField] private Transform LeftClaw;
    [SerializeField] private Transform RightClaw;

    [SerializeField] private float leftRotate, rightRotate;

    GameStateManager gameStateManager;

    public bool isGrabbing;

    private void Awake()
    {
        playercontrols = new PlayerControls();
    }

    private void Start()
    {
        isGrabbing = false;
        gameStateManager = FindObjectOfType<GameStateManager>();

        if (gameStateManager != null)
        {
            gameStateManager.TimeRanOut += TimePunishment;
        }
    }


    private void Update()
    {

        if (isGrabbing || gameStateManager.lives <= 0)
        {
            gameStateManager.timeIsRunning = true;
        }
        else
        {
            gameStateManager.timeIsRunning = false;
            gameStateManager.ResetTime();
        }


    }

    private void TimePunishment(object sender, EventArgs e)
    {
        if(isGrabbing)
        {
            LetGo();
        }
        else
        {
            gameStateManager.changeLives(-1);
        }

    }

    private void OnEnable()
    {
        playercontrols.PlayerMovement.Grab.performed += Grab;
        playercontrols.PlayerMovement.Grab.Enable();
    }


    private void Grab(InputAction.CallbackContext obj)
    {
        if (!PauseManager.isPaused)
        {
            if(LeftClaw != null && RightClaw != null)
            {
                if (isGrabbing)
                {
                    LetGo();

                }
                else if(gameStateManager.lives >0)
                {
                    LeftClaw.transform.Rotate(0f, 0f, leftRotate);
                    RightClaw.transform.Rotate(0f, 0f, rightRotate);
                    isGrabbing = true;


                   // if (gameStateManager != null)
                   // {
                        gameStateManager?.changeLives(-1);
                   // }
                }
            }
        }

    }

    public void LetGo()
    {
            LeftClaw.transform.Rotate(0f, 0f, -leftRotate);
            RightClaw.transform.Rotate(0f, 0f, -rightRotate);
            isGrabbing = false;

    }


}
