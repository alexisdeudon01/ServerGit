
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Collections;
using System;
public class ClientNetworkManager : MonoBehaviour
{
    public string ip;
    public int port;
    public bool isConnected;

    public SessionManager sessionManager=SessionManager.Instance;
   public void Awake()
    {
        if (sessionManager == null)
        {
            Debug.LogError("SessionManager not set on ClientNetworkManager!");
            return;
        }
    ip="127.0.0.1";
    port=7779;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
           var net = NetworkManager.Singleton;
    var transport = net.GetComponent<UnityTransport>();
  
    // Vérifier que l'ip n'est pas vide
    if (string.IsNullOrWhiteSpace(ip))
    {
        Debug.LogError("ClientNetworkManager: IP address is empty or invalid!");
        return;
    }

    transport.SetConnectionData(ip, (ushort)port, null);

    if (!net.StartClient())
{
    Debug.LogError("Cannot start client.");
    return;
}
else
{
    Debug.Log("Client start requested — waiting for real connect...");
    isConnected = false; // ne pas set true tout de suite

    net.OnClientConnectedCallback += OnClientConnected;
   // net.OnClientDisconnectCallback += OnClientDisconnected; // gérer aussi l’échec
}
    }

private  void OnClientConnected(ulong clientId)
    {
        Debug.Log("Client connected with ID: " + clientId);
        isConnected = true;
        Player player= new Player("Player"+clientId, "player@email.com");
        Debug.Log("Player created: " + player.PlayerName);
        String line="";        
        foreach(GameSession gs in sessionManager.GetSessions())
        {
            Debug.Log("Checking session: " + gs.SessionId+" with " + gs.Players.Count + " players.  Max players: " + gs.MaxPlayers      );
              Console.Write("Press Y to join this session or N to skip: ");
                line = Console.ReadLine();
                if (line == "Y" || line == "y")
                {
                    
                sessionManager.AddPlayerToSession(player, gs);
                Debug.Log("Player " + player.PlayerName + " added to session " + sessionManager.GetSessions()[gs.SessionId].SessionId);
                    
                    return;
            }
        }
        Console.WriteLine("No suitable session found. Creating a new session.");
        sessionManager.CreateSession();
        sessionManager.AddPlayerToSession(player, sessionManager.GetSessions()[sessionManager.GetSessions().Count - 1] );
        Debug.Log("Player " + player.PlayerName + " added to new session " + sessionManager.GetSessions()[sessionManager.GetSessions().Count - 1].SessionId);
    }
   /* private void OnClientDisconnected(ulong clientId)
    {
        foreach(GameSession gs in sessionManager.GetAllSessions())
        {
            foreach(Player p in gs.Players)
            {
                if (p.PlayerName == "Player"+clientId)
                {
                    sessionManager.RemovePlayerFromSession(p, gs);
                    Debug.Log("Player " + p.PlayerName + " removed from session " + gs.SessionId);
                    break;
                }
            }
        }
        Debug.Log("Client disconnected with ID: " + clientId);
        isConnected = false;
    }*/
   

}

