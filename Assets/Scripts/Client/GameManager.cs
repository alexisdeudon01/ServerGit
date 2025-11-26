using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Config config;
    public GameSession currentSession;
    public bool currentMatchInProgress;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitGame()
    {
        if( currentMatchInProgress==false)
        {
  
        }
        else
        {
            Debug.Log("Match already in progress");
        }
    }
    public void startMatch()
    {
            currentSession = new GameSession();
            currentSession.SessionId = System.Guid.NewGuid().ToString();
            currentSession.MaxPlayers = config.maxPlayersPerSession;
            currentMatchInProgress = true;
            Debug.Log("Match started");
        
    }
    public void endMatch()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
