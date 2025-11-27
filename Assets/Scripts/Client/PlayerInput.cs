using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem; // important pour le New Input System

public class PlayerInput : MonoBehaviour
{
    [SerializeField] LocalPlayerController controller; // si tu t'en sers ailleurs
    [SerializeField] float speed = 5f;

    public float horizontal;
    public float vertical;
    public bool forwardPressed;
    public bool backwardPressed;
    public bool leftPressed;
    public bool rightPressed;

    // classe générée par ton Input Actions (nom à adapter si besoin)
    private InputSystem_Actions input;

    void Awake()
    {
        input = new InputSystem_Actions();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    public void readInput()
    {
        Vector2 move = input.Player.Move.ReadValue<Vector2>();

        horizontal = move.x;
        vertical = move.y;

        forwardPressed = move.y > 0.1f;   // haut
        backwardPressed = move.y < -0.1f;  // bas
        rightPressed = move.x > 0.1f;   // droite
        leftPressed = move.x < -0.1f;  // gauche
    }

    public void resetInput()
    {
        horizontal = 0f;
        vertical = 0f;
        forwardPressed = false;
        backwardPressed = false;
        leftPressed = false;
        rightPressed = false;
    }

 
    void Start()
    {
        resetInput();
    }

    void Update()
    {
        // 1) lire l'input
        readInput();


        if (controller != null)
        {
            Vector2 move = new Vector2(horizontal, vertical);
            controller.HandleLocalMovement(move);
            Debug.Log("Input read: " + move);
        }
        
    }
}
