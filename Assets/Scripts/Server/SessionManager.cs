using UnityEngine;

public class SessionManager : MonoBehaviour
{
    [SerializeField] GameSession session;
    public int maxSessions;
    public int activeSessionsCount;


    public void CreateSession()
    {
        if (activeSessionsCount >= maxSessions) return;

        session = new GameSession();
        activeSessionsCount++;
    }
    public GameSession FindSessionForPlayer(Player player)
    {
        List<GameSession> sessions = new List<GameSession>(GameObject.FindGameObjectsWithTag("GameSession"));
        for each(GameSession gs in sessions)
        {
            for each(Player p in gs.Players)
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
