using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Netcode;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameManager()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    


    [SerializeField]
    public SessionManager sessionManager;
    [SerializeField]
    public Config config;
    [SerializeField]
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
            currentSession = sessionManager.CreateSession();
          
            Debug.Log("Match started" + GameSession.SessionId+   " with " + currentSession.Players.Count + " players."   );

        
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
