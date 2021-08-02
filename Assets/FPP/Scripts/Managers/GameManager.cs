using System;
using FPP.Scripts.Systems;
using FPP.Scripts.Patterns;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private Player _player;
        private SaveSystem _saveSystem;
        
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        void Start()
        {
            InitGame();
        }

        private void InitGame()
        {
            _sessionStartTime = DateTime.Now;
            
            _saveSystem = new SaveSystem();
            _player = _saveSystem.LoadPlayer();
            
            if (_player == null)
                SceneManager.LoadScene("Registration");
            else
                SceneManager.LoadScene("MainMenu");
        }

        private void GetDailyChallenges()
        {
            // TODO: Implement call to endpoint to get daily challenges from the backend
        }
        
        void OnApplicationQuit() 
        {
            _sessionEndTime = DateTime.Now;
            
            TimeSpan timeDifference = 
                _sessionEndTime.Subtract(_sessionStartTime);

            _player.lastSessionDuration = timeDifference;
            
            _saveSystem.SavePlayer(_player);
        }
    }
}