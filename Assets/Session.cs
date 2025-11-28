using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class Session : MonoBehaviour
{
    [SerializeField] private bool isServer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var net = NetworkManager.Singleton;
        var config = net.GetComponent<UnityTransport>().ConnectionData;
        if (isServer == true)
        {
            Debug.Log("Starting client to connect to server at 127.0.0.1:7778");
            config.Address = "127.0.0.1";
            config.Port = 7778;
            net.StartClient();
            Debug.Log("Client started");
        }
        else
        {
            config.Port = 7778;
            Debug.Log("Starting server on port 7778");
            net.StartServer();
            Debug.Log("Server started");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}

