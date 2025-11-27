using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
public class ServerNetworkManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int listenPort = 7778;
    public bool isRunning = false;
    public void StartServer()
    {
        var net = NetworkManager.Singleton;
        var transport= net.GetComponent<UnityTransport>();
        transport.ConnectionData.Port = (ushort)listenPort;
        if(net.IsServer)
        {
            Debug.Log("Server already running");
            return;
        }
        if(!net.StartServer())
        {
            Debug.LogError("Failed to start server: " );
            return;
        }
        else
        {
            Debug.Log("Server started successfully");
            isRunning = true;
        }
    }
    public void StopServer()
    {
        var net = NetworkManager.Singleton;
        //net.StopServer();
        isRunning = false;

    }
    //public void ReceiveMoveCommand(Player player , Pion pion)
    //{
        // Process the move command from the player for the specified pion
        // This is a placeholder for actual game logic
      //  Debug.Log($"Received move command from Player {player.Id} for Pion at position ({pion.x}, {pion.y})");

        
    //}
    void Start()
    {
        StartServer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
