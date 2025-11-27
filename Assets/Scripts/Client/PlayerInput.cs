using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LocalPlayerController controller;
    [SerializeField] private float speed = 5f;

    // Classe générée à partir de PlayerControls.inputactions
    private PlayerControls inputControls;

    private Vector2 moveInput;

    void Awake()
    {
        inputControls = new PlayerControls();
    }

    void OnEnable()
    {
        // active l’action map “Player”
        inputControls.Player.Enable();
    }

    void OnDisable()
    {
        inputControls.Player.Disable();
    }

    void Update()
    {
        // lire la valeur actuelle de l’action “Move”
        moveInput = inputControls.Player.Move.ReadValue<Vector2>();

        // si tu veux, tu peux filtrer la deadzone ici
        float dx = moveInput.x;
        float dy = moveInput.y;

        Vector2 move = new Vector2(dx, dy);

        // debugger
        Debug.Log("Input read: " + move);

        // envoyer au controller si défini
        if (controller != null)
        {
            controller.HandleLocalMovement(this);
        }
    }
}
