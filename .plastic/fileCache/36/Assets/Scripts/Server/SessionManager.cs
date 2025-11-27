using UnityEngine;
using System.Collections.Generic;

public class SessionManager : MonoBehaviour
{


   
    private int maxSessions=10;
    private List<GameSession> sessions = new List<GameSession>();

    public IReadOnlyList<GameSession> Sessions => sessions;
    public static SessionManager Instance { get; private set; }
    public List<GameSession> GetSessions()
    {
        return sessions;
    }
    public void Awake()
    {
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

    public List<GameSession> GetAllSessions()
    {
        // retourne une copie ou IReadOnlyList pour éviter modification externe
        return new List<GameSession>(sessions);
    }

    public GameSession CreateSession()
    {
        if (sessions.Count >= maxSessions) return null;

        var newSession = new GameSession();
        sessions.Add(newSession);
        return newSession;
    }

    public GameSession FindSessionForPlayer(Player player)
    {
        if (player == null) return null;

        foreach (var gs in sessions)
        {
            if (gs.Players.Contains(player))
                return gs;
        }
        return null;
    }

    public bool AddPlayerToSession(Player player, GameSession session)
    {
        if (session == null || player == null) return false;
        if (!session.CanAcceptPlayer()) return false;

        session.AddPlayer(player);
        return true;
    }

    public bool RemovePlayerFromSession(Player player, GameSession session)
    {
        if (session == null || player == null) return false;

        session.RemovePlayer(player);
        return true;
    }

    void Start()
    {
        // Optionnel : créer une session automatiquement si aucune
        if (sessions.Count == 0)
        {
            CreateSession();
        }
        else
        {
            Debug.Log("Existing session(s) detected on start.");
        }
    }

    // Update si besoin — sinon tu peux l’enlever
    void Update()
    {
    }
}
