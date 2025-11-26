using UnityEngine;

public class ServerNetworkManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int listenPort = 7777;
    public bool isRunning = false;
    public void StartServer()
    {
        var net = ServerNetworkManager.Singleton;
        net.StartServer(listenPort);
        isRunning = true;
    }
    public void StopServer()
    {
        var net = ServerNetworkManager.Singleton;
        net.StopServer();
        isRunning = false;

    }
    public void ReceiveMoveCommand(Player player , Pion pion)
    {
        // Process the move command from the player for the specified pion
        // This is a placeholder for actual game logic
        Debug.Log($"Received move command from Player {player.Id} for Pion at position ({pion.x}, {pion.y})");

        
    }
    void Start()
    {
        StartServer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
