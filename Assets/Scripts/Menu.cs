using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    void Awake()
{
    // Si ce n’est pas déjà le singleton, on le détruit pour éviter les doublons
    if (NetworkManager.Singleton == null)
    {
        Debug.Log("Menu: Setting NetworkManager singleton instance.");
        // Ce GameObject ne sera pas détruit quand on change de scène
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Debug.Log("Menu: NetworkManager singleton instance already exists.");
        // Si un autre NetworkManager existe, on détruit celui-ci
       // Destroy(gameObject);
    }
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void OnClickStartGameButtonServer()
    {
        Debug.Log("Start Game button clicked");
        SceneManager.LoadScene("Server");
        // Load the game scene or initialize game start logic here
    }
    public void onClickQuitButtonClient()
    {
        Debug.Log("Quit button clicked");
        SceneManager.LoadScene("Client");
        Application.Quit();
    }
}
