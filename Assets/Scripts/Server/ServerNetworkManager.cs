using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class ServerNetworkManager : MonoBehaviour
{
    public int listenPort = 7778;
    public bool isRunning = false;

    void Awake()
    {
        // Optional: s'assurer qu'on a bien un NetworkManager singleton
        if (NetworkManager.Singleton == null)
        {
            Debug.LogError("No NetworkManager singleton found!");
            //return;
        }
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Port = (ushort)listenPort;
    }

    void Start()
    {
        StartServer();
    }

    public void StartServer()
    {
        var net = NetworkManager.Singleton;
        if (net.IsServer)
        {
            Debug.Log("Server already running");
            return;
        }
        if (!net.StartServer())
        {
            Debug.LogError("Failed to start server");
        }
        else
        {
            Debug.Log("Server started successfully on port " + listenPort);
            isRunning = true;
            NetworkManager.Singleton.OnServerStarted += OnServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
        }
    }
    private void OnServerStarted()
    {
        Debug.Log("Server has started successfully.");
    }

    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client connected: {clientId}");
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"Client disconnected: {clientId}");
    }

    public void StopServer()
    {
        var net = NetworkManager.Singleton;
        if (net.IsServer)
        {
            net.Shutdown();  // arrête réellement le serveur
            isRunning = false;
            Debug.Log("Server stopped");
        }
    }
}
