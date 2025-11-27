using UnityEngine;
using System.Collections.Generic; 
public class SessionManager : MonoBehaviour
{
    [SerializeField] GameSession session;
    public int maxSessions;
    public int activeSessionsCount;
    public List<GameSession> sessions = new List<GameSession>();
    public List<GameSession> GetAllSessions()
    {
        return sessions;
    }

    public GameSession CreateSession()
    {
        if (activeSessionsCount >= maxSessions) return null;

        session = new GameSession();
        activeSessionsCount++;
        sessions.Add(session);

        return session;
    }
    public GameSession FindSessionForPlayer(Player player)
    {
        foreach(GameSession gs in GameManager.Instance.sessionManager.GetAllSessions())
        {
            foreach(Player p in gs.Players)
            {
                if (p == player)
                {
                    return gs;
                }
            }
        }

        return null;
    }
    public void AddPlayerToSession(Player player, GameSession session)
    {
        if (session == null) return;
        if (player == null) return;
        if (!session.CanAcceptPlayer()) return;

        session.AddPlayer(player);

    }
    public void RemovePlayerFromSession(Player player, GameSession session)
    {
        if (session == null) return;
        if (player == null) return;

        session.RemovePlayer(player);   
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(session==null)
        {
            CreateSession();
        }
        else{
            Debug.Log("Session already exists");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
