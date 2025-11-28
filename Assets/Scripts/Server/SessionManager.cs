
using UnityEngine;
using System.Collections.Generic;

public class SessionManager : MonoBehaviour
{
    // Singleton
    public static SessionManager Instance { get; private set; }

    [SerializeField] private int maxSessions = 10;
    private List<GameSession> sessions = new List<GameSession>();

    // Exposition en lecture seule
    public IReadOnlyList<GameSession> Sessions => sessions.AsReadOnly();
    public GameSessionChooseSession(Player p){
        if(sessions.Count()==0)
        {
            String b=Console.write("No sessions created, would you like to create one")
            if(b=='Y'){
                return CreateSession()
            }
            else{
                return;
            }
        }
        else{
            Console.write("Sessions en cours");
            int i=1;
            foeach(GameSession gs in sessions){
                int id=gs.SessionId;
                 List<Player>Players=gs.ListPlayers();
                Console.write(id+ " "+sessions.ListPlayers.Count())
                foreach(Player player in Players){
                    Console.write("Player "+player.name);
                }
                
                

            }
            String aa=Console.write("Quel session voulez vous ?")
            GameSession choosenSession=FindSessionById(aa);
            AddPlayerToSession(p,choosenSession);
        }
    }
    public GameSessio
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("SessionManager: Instance already exists, destroying duplicate.");
            Destroy(gameObject);
            return;
        }
        Debug.Log
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
            if(cs.SessionId=id){
                return cs;
            }
        }
    }
    public List<GameSession> GetSessions()
    {
        return sessions;
    }
    
}
>>>>>>> 678951c (ezflksk)
