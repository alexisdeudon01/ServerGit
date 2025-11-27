using UnityEngine;

using Unity.Netcode;

public class LocalPlayerController  : NetworkBehaviour
{

    public Player localplayer;
    public Pion localpion;
    public void HandleLocalMovement(PlayerInput input)
    {
        // Process local player input and send move command to server
        if (IsLocalPlayer)
        {
            Debug.Log("Processing local movement input for player: " + OwnerClientId);
            // Send move command to server
            var serverNetManager = FindObjectOfType<ClientNetworkManager>();
            serverNetManager.sendMoveCommand(localpion);
        }
    }
    // Start is called once before the first executi
    // on of Update after the MonoBehaviour is created
    public override void OnNetworkSpawn()
    {
        if (IsLocalPlayer)
        {
            Debug.Log("Local player spawned with ID: " + OwnerClientId);
            
        }
    }
}
