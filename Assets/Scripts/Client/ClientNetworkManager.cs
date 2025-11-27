
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Collections;
using System;
public class ClientNetworkManager : NetworkBehaviour
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
            net.OnClientConnectedCallback+=onClientConnected;
            net.OnClientDisconnectedCallback+=onClientDisconnected;
        }   

public void onClientConnected(ulong clientId)
    {
        Debug.Log("Client connected with ID: " + clientId);
        isConnected = true;
        Player player= new Player("Player"+clientId, "player@email.com");
        Debug.Log("Player created: " + player.PlayerName);
        string line;        
        for each(GameSession gs in sessionManager.GetAllSessions())
        {
            Debug.Log("Checking session: " + gs.SessionId+" with " + gs.Players.Count + " players.  Max players: " + gs.MaxPlayers      );
              Console.Write("Press Y to join this session or N to skip: ");
                line = Console.ReadLine();
                if (line == "Y" || line == "y")
                {
                    
                sessionManager.AddPlayerToSession(player, gs);
                Debug.Log("Player " + player.PlayerName + " added to session " + gs.SessionId);
                
                return;
            }
        }
        Console.WriteLine("No suitable session found. Creating a new session.");
        GameManager.Instance.sessionManager.CreateSession();
        sessionManager.AddPlayerToSession(player, sessionManager.GetLatestSession());
        Debug.Log("Player " + player.PlayerName + " added to new session " + sessionManager.GetLatestSession().SessionId);
    }
    public void onClientDisconnected(ulong clientId)
    {
        for each(GameSession gs in GameManager.Instance.sessionManager.GetAllSessions())
        {
            for each(Player p in gs.Players)
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
    }
   

}

