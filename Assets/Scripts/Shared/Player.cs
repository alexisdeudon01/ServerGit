using System;

    public class Player
    {
        public string PlayerName;
        public string Email;

        public GameSession CurrentSession;
        public Player(string playerName, string email)
        {
            PlayerName = playerName;
            Email = email;
        }
        public void JoinSession(GameSession session)
        {
            CurrentSession = session;
            session.AddPlayer(this);
        }

        public void LeaveSession()
        {
            if (CurrentSession == null) return;
            CurrentSession.RemovePlayer(this);
            CurrentSession = null;
        }
    }

