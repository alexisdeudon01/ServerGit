
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Collections;

public class ClientNetworkManager : MonoBehaviour
{
    public string ip="127.0.0.1";
    public int port=7778;
    public bool isConnected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
           
        
        var net= NetworkManager.Singleton;

        var transport= net.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ip;
        transport.ConnectionData.Port = (ushort)port;
        if(!net.StartClient())
        {       
           Debug.LogError("Failed to start client: " );
        }
        else
        {
            Debug.Log("Client started successfully");
            isConnected = true;
        }   

    }
    

   
    public void joinSessionRequest(string sessionId)
    {
        if (!isConnected)
        {
            Debug.LogWarning("Client is not connected to the server.");
            return;
        }

        // Create and send the join session request message to the server
     
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
  
         
        

        //NetworkManager.Singleton.CustomMessagingManager.SendNamedMessage("MoveCommand", NetworkManager.Singleton.ServerClientId, moveCommand);
    }
}

