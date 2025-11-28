using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LocalPlayerController controller;
    private PlayerControls inputControls;

    private Vector2 moveInput;

    void Awake()
    {
        inputControls = new PlayerControls();
    }

    void OnEnable()
    {
        inputControls.Player.Enable();
    }

    void OnDisable()
    {
        inputControls.Player.Disable();
    }

    void Update()
    {
        moveInput = inputControls.Player.Move.ReadValue<Vector2>();

        // si tu utilises un bouton pour "afficher position", par ex une action "ShowPosition"
        // ou tu peux détecter n'importe quelle touche
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            // affiche la position uniquement quand une touche vient d'être pressée
            controller?.ShowPosition();
        }

        // envoi le mouvement au controller (si applicable)
      //  controller?.HandleLocalMovement(moveInput);
    }
}
