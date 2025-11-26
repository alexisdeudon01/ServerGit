using UnityEngine;

public class ClientNetworkManager : NetworkManager
{
    public string ip;
    public int port;
    public bool isConnected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        try
        {
            StartClient();
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to start client: " + e.Message);
        }  
    }

    public void connectToServer(string ip, int port)
    {
        NetworkManager.Singleton.StartClient();
    }
    public void joinSessionRequest(string sessionId)
    {
        if (!isConnected)
        {
            Debug.LogWarning("Client is not connected to the server.");
            return;
        }

        // Create and send the join session request message to the server
        JoinSessionRequestMessage joinRequest = new JoinSessionRequestMessage
        {
            SessionId = sessionId
        };

        //NetworkManager.Singleton.CustomMessagingManager.SendNamedMessage("JoinSessionRequest", NetworkManager.Singleton.ServerClientId, joinRequest);
    }
    public void sendMoveCommand(Pion pion)
    {
        if (!isConnected)
        {
            Debug.LogWarning("Client is not connected to the server.");
            return;
        }

        // Create and send the move command message to the server
        MoveCommandMessage moveCommand = new MoveCommandMessage
        {
            pionX = pion.x,
            pionY = pion.y
        };

        //NetworkManager.Singleton.CustomMessagingManager.SendNamedMessage("MoveCommand", NetworkManager.Singleton.ServerClientId, moveCommand);
    }
}
