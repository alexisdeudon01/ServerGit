using System.Collections.Generic;
using System;
    public class GameSession
    {
        public int SessionId;
        public int MaxPlayers;

        public List<Player> Players = new List<Player>();
        public GameSession()
        {
            Players = new List<Player>();
            SessionId = GameManager.Instance.sessionManager.sessions.Count;
            GameManager.Instance.sessionManager.sessions.Add(this);
            SessionId++;
        }
        public bool CanAcceptPlayer()
        {
            return Players.Count < MaxPlayers;
        }

        public void AddPlayer(Player player)
        {
            if (Players.Contains(player)) return;
            if (!CanAcceptPlayer()) return;

            Players.Add(player);
            player.CurrentSession = this;
        }

        public void RemovePlayer(Player player)
        {
            if (!Players.Contains(player)) return;

            Players.Remove(player);
            if (player.CurrentSession == this)
                player.CurrentSession = null;
        }
    }   
