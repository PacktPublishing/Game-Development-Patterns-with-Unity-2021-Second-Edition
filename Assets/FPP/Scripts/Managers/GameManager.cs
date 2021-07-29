using System;
using UnityEngine;
using FPP.Scripts.Core;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.Managers
{ 
    public class GameManager : Singleton<GameManager> 
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        void Start() 
        {
            _sessionStartTime = DateTime.Now;
            
            Debug.Log(
                "Game session start @: " + DateTime.Now);
        }
        
        void OnApplicationQuit() {
            _sessionEndTime = DateTime.Now;
            
            TimeSpan timeDifference = 
                _sessionEndTime.Subtract(_sessionStartTime);
            
            Debug.Log(
                "Game session ended @: " + DateTime.Now);
            Debug.Log(
                "Game session lasted: " + timeDifference);
        }

        void OnGUI() {
            if (GUILayout.Button("Next Scene")) {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}