// Assets/Scripts/Shared/Config.cs
using UnityEngine;

namespace MyGame.Shared
{
    [CreateAssetMenu(
        fileName = "Config",
        menuName = "MyGame/Config",
        order = 0)]
    public class Config : ScriptableObject
    {
        public int maxPlayers = 4;
        public float moveSpeed = 5f;
        public int tickRate = 30;
    }
}
