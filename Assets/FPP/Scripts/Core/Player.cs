using System;
using FPP.Scripts.Interfaces;
using System.Collections.Generic;

namespace FPP.Scripts.Core
{
    [Serializable]
    public class Player
    {
        public int currentTrack;
        public string playerName;
        public string playerUid; // TODO: Implement a UID generator
        public TimeSpan lastSessionDuration;
        public List<IInventoryItem> inventory;
    }
}