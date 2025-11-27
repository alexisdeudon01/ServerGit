using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBootstrap : MonoBehaviour
{
    void Start()
    {
        if (Application.isBatchMode)
        {
            // serveur en headless mode
            SceneManager.LoadScene("ServerScene");
        }
        else
        {
            // client normal
            SceneManager.LoadScene("ClientScene");
        }
    }
}
