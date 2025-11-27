using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
    public NetworkManager net;
    public SessionManager sessionManager;
    public Config config;
    public GameSession currentSession;
    public bool currentMatchInProgress=false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitGame()
    {
        if( currentMatchInProgress==false)
        {
            startMatch();
        currentMatchInProgress=true;
        }
        else
        {
            
            Debug.Log("Match already in progress");
        }
    }
    public void startMatch()
    {
            currentSession = new GameSession();
          
            Debug.Log("Match started" + currentSession.SessionId+   " with " + currentSession.Players.Count + " players."   );

        
    }
    public void endMatch()
    {

    }
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
