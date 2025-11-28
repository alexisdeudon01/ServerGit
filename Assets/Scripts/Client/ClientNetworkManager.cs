using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using System.Collections.Generic;

public class ClientNetworkManager : MonoBehaviour
{
    [Header("Connection settings")]
    public string ip = "127.0.0.1";
    public ushort port = 7778;

    public bool isConnected { get; private set; }

    public SessionManager sessionManager = SessionManager.Instance;

    void Awake()
    {
     
    }

    void Start()
    {
           if (NetworkManager.Singleton == null)
        {
            Debug.LogError("ClientNetworkManager: No NetworkManager in scene!");
            enabled = false;  // disable this component
            return;
        }

        if (sessionManager == null)
        {
            Debug.LogError("ClientNetworkManager: SessionManager not found!");
            enabled = false;
            return;
        }
        var net = NetworkManager.Singleton;
        var transport = net.GetComponent<UnityTransport>();
        if (transport == null)
        {
            Debug.LogError("ClientNetworkManager: UnityTransport component missing on NetworkManager!");
            return;
        }

        if (string.IsNullOrWhiteSpace(ip))
        {
            Debug.LogError("ClientNetworkManager: IP address is empty or invalid!");
            return;
        }

        transport.SetConnectionData(ip, port, null);

        bool started = net.StartClient();
        if (!started)
        {
            Debug.LogError($"ClientNetworkManager: StartClient() failed for {ip}:{port}");
            return;
        }

        Debug.Log($"ClientNetworkManager: Client start requested — connecting to {ip}:{port}");
        isConnected = false;

        net.OnClientConnectedCallback += OnClientConnected;
        net.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        if (clientId != NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("Connection refused, already connec"ted)
            // un autre client s'est connecté — si tu ne gères que le client local, ignore
            return;
        }

        Debug.Log("ClientNetworkManager: Connected to server, local client ID = " + clientId);
        isConnected = true;
        String nom=Console.write("Quel est votre pseudo");
        Player p=new Player(nom,"");
        

        // Exemple simple : demander de rejoindre une session via UI plutôt que Console
        // Ici tu peux déclencher un événement Unity ou appeler une méthode UI
    }

    private void OnClientDisconnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("ClientNetworkManager: Disconnected from server");
            isConnected = false;
        }
    }

    // Méthode pour demander au serveur d'ajouter le joueur à une session
    public void RequestJoinSession()
    {
        if (!isConnected) return;

        // Par ex., tu pourrais appeler un ServerRpc ici
        // Serveur: ajouter le Player + session logique
    }
}
