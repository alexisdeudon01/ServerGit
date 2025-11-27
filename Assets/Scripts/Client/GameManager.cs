using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Netcode;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Référence à ton gestionnaire de sessions
    [SerializeField] 
    public SessionManager sessionManager;

    // Config globale du jeu
    [SerializeField]
    public Config config;

    // Session de jeu en cours
    public GameSession currentSession { get; private set; }

    public bool currentMatchInProgress = false;

    void Awake()
    {
        // Singleton pattern — s'assurer qu'une seule instance existe
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Initialise / démarre la partie si aucune en cours
    public void InitGame()
    {
        if (!currentMatchInProgress)
        {
            StartMatch();
            currentMatchInProgress = true;
        }
        else
        {
            Debug.LogWarning("Match already in progress");
        }
    }

    // Démarrage d'une nouvelle session
    public void StartMatch()
    {
        if (sessionManager == null)
        {
            Debug.LogError("SessionManager not set on GameManager!");
            return;
        }

        currentSession = sessionManager.CreateSession();
        if (currentSession != null)
        {
            Debug.Log("Match started: " + currentSession.SessionId +
                      " with " + currentSession.Players.Count + " players.");
        }
        else
        {
            Debug.LogError("Failed to create session");
        }
    }

    public void EndMatch()
    {
        // Ton code de fin de match ici
        currentMatchInProgress = false;
        currentSession = null;
    }

    void Start()
    {
        InitGame();
    }

    void Update()
    {
        // logique par frame, si besoin
    }

    // Optionnel : méthode utilitaire pour redémarrer ou reset game
    public void ResetGame()
    {
        EndMatch();
        InitGame();
    }
}
