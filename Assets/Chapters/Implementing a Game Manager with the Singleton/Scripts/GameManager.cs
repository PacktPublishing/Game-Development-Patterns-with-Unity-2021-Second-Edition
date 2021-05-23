using System;
using UnityEngine;

namespace Chapter.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        void Start()
        {
            // TODO:
            // - Load player save
            // - If no save, redirect player to registration view
            // - Call backend and get daily challenge and rewards 

            _sessionStartTime = DateTime.Now;
            Debug.Log("Game session start @: " + DateTime.Now);
        }
        
        void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;
            TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);
            
            Debug.Log("Game session ended @: " + DateTime.Now);
            Debug.Log("Game session lasted: " + timeDifference);
        }
    }
}