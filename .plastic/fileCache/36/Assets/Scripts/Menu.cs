using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
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
