using UnityEngine;
using Unity.Netcode;

public class LocalPlayerController : NetworkBehaviour
{
    public Player localplayer;
    public Pion localpion;

    void Update()
    {
        if (!IsLocalPlayer) return;

        // On pourrait écouter une entrée (touche) ici pour afficher sa position ou demander un move
        if (Input.GetKeyDown(KeyCode.P))  // exemple : touche P pour “print position”
        {
            ShowPosition();
        }
    }

    public void HandleLocalMovement(Vector2 input)
    {
        if (!IsLocalPlayer) return;

        Debug.Log("Processing local movement input for player: " + OwnerClientId);

        // Appeler RPC pour envoyer la demande de déplacement au serveur
        RequestMoveServerRpc(input);
    }

    [ServerRpc]  // méthode pour envoyer la demande au serveur
    private void RequestMoveServerRpc(Vector2 moveInput, ServerRpcParams rpcParams = default)
    {
        // Ici : logique serveuse pour déplacer le pion (ou valider mouvement), 
        // puis éventuellement synchroniser la position aux clients
        ApplyMove(moveInput);
    }

    private void ApplyMove(Vector2 moveInput)
    {
        // Exemple : modifier la position Unity du gameobject / du pion
        transform.position += new Vector3(moveInput.x, moveInput.y, 0);
        // Si tu as un système "grille + Pion data" :
        // localpion.Move(...) ou quelque chose selon direction
    }

    public void ShowPosition()
    {
        Vector3 pos = transform.position;
        Debug.Log("My position: " + pos);
    }

    public override void OnNetworkSpawn()
    {
        if (IsLocalPlayer)
        {
            Debug.Log("Local player spawned with ID: " + OwnerClientId);
        }
    }
}
