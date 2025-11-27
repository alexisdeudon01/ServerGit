using UnityEngine;

public class ServerGameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Config config;
    public GameSession currentSession;
    public bool currentMatchInProgress;
    public void createSession()
    {
        currentSession = new GameSession();

      //  currentSession.MaxPlayers = config.maxPlayersPerSession;
        currentMatchInProgress = true;
        Debug.Log("Match started");

    }
    public void endSession()
    {

    }
    public void Tick(float deltaTime)
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
