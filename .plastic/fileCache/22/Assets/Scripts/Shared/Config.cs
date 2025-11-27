// Assets/Scripts/Shared/Config.cs
using UnityEngine;
using System;
namespace Shared // Replace with your actual namespace if you have one
{   

[CreateAssetMenu(fileName = "Config", menuName = "Game/Config")]
    public class Config : ScriptableObject
    {
        public int maxPlayers = 4;
        public float moveSpeed = 5f;
        public int tickRate = 30;
    }
}
