
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEditor;

public class SessionManager : MonoBehaviour
{
    // Singleton
    public static SessionManager Instance { get; private set; }

    [SerializeField] private int maxSessions = 10;
    private List<GameSession> sessions = new List<GameSession>();

    // Exposition en lecture seule 
    // 
        public IReadOnlyList<GameSession> Sessions => sessions.AsReadOnly();
    public GameSession GameSessionChooseSession(Player p){
        if (sessions.Count() == 0)
        {
            string b;
            Console.Write("No sessions created, would you like to create one");
            b = Console.ReadLine();
            if (b == "Y")
            {
                return CreateSession();
            }
            else
            {
                return null;
            }
        }
        else
        {
            Console.Write("Sessions en cours");
            int i = 1;
            foreach (GameSession gs in sessions)
            {
                int id = gs.SessionId;
                List<Player> Players = gs.Players;
                Console.Write(id + " " + gs.Players.Count());
                foreach (Player player in Players)
                {
                    Console.Write("Player " + player.PlayerName);
                }



            }
            int aa;
            Console.Write("Quel session voulez vous ?");
            aa = Console.Read();
            GameSession choosenSession = FindSessionById(aa);
            AddPlayerToSession(p, choosenSession);
        }
        return null;
    }
  
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("SessionManager: Instance already exists, destroying duplicate.");
            Destroy(gameObject);
            return;
        }
        Debug.Log("fdsl");
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Optionally, initialize default session
        if (sessions.Count == 0)
        {
            var s = CreateSession();
            Debug.Log("SessionManager: Created initial session with ID " + (s != null ? s.SessionId.ToString() : "null"));
        }
    }

    public GameSession CreateSession()
    {
        if (sessions.Count >= maxSessions)
        {
            Debug.LogWarning("SessionManager: Cannot create session — maxSessions reached.");
            return null;
        }

        GameSession newSession = new GameSession();
        sessions.Add(newSession);
        return newSession;
    }

    public bool AddPlayerToSession(Player player, GameSession session)
    {
        if (player == null || session == null)
            return false;

        if (!session.CanAcceptPlayer())
            return false;

        session.AddPlayer(player);
        return true;
    }

    public bool RemovePlayerFromSession(Player player, GameSession session)
    {
        if (player == null || session == null)
            return false;

        session.RemovePlayer(player);
        return true;
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
    public GameSession FindSessionById(int id){
        foreach(GameSession cs in sessions){
            if(cs.SessionId==id){
                return cs;
            }
        }return null;
    }
    public List<GameSession> GetSessions()
    {
        return sessions;
  }
    }

