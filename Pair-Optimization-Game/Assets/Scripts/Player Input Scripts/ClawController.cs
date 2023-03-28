using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class ClawController : MonoBehaviour
{
    private PlayerControls playercontrols;

    [SerializeField] private Transform LeftClaw;
    [SerializeField] private Transform RightClaw;

    [SerializeField] private float leftRotate, rightRotate;

    GameStateManager gameStateManager;
    public bool isGrabbing;


    private AudioSource audioSource;
    [SerializeField] AudioClip grabSFX, dropSFX;

    private void Awake()
    {
        playercontrols = new PlayerControls();
    }

    private void Start()
    {
        isGrabbing = false;
        gameStateManager = FindObjectOfType<GameStateManager>();
        audioSource = GetComponent<AudioSource>();

        if (gameStateManager != null)
        {
            gameStateManager.TimeRanOut += TimePunishment;
        }
    }
    private void TimePunishment(object sender, EventArgs e) //Functions that occur when time runs out
    {
        if (isGrabbing)
        {
            LetGo();
        }
        else
        {
            GrabObject();
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
            if (LeftClaw != null && RightClaw != null)
            {
                if (isGrabbing)
                {
                    LetGo();

                }
                else if (gameStateManager.lives > 0)
                {
                    GrabObject();
                }
            }

        }
    }

    public void LetGo()
    {
        LeftClaw?.transform.Rotate(0f, 0f, -leftRotate);
        RightClaw?.transform.Rotate(0f, 0f, -rightRotate);

        audioSource.PlayOneShot(dropSFX);

        isGrabbing = false;

    }

    public void GrabObject()
    {
        LeftClaw?.transform.Rotate(0f, 0f, leftRotate);
        RightClaw?.transform.Rotate(0f, 0f, rightRotate);

        audioSource.PlayOneShot(grabSFX);
        gameStateManager.ResetTime();

        isGrabbing = true;
        gameStateManager.changeLives(-1);
    }


}
