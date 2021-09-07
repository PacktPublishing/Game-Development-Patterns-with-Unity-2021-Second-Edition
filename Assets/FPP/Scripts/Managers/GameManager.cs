using System;
using UnityEngine;
using FPP.Scripts.Core;
using FPP.Scripts.Systems;
using FPP.Scripts.Patterns;
using FPP.Scripts.Services;
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
            RegisterGlobalServices();
            LoadPlayer();
            StartSessionTimer();
        }

        private void StartSessionTimer()
        {
            _sessionStartTime = DateTime.Now;
        }

        private void LoadPlayer()
        {
            _saveSystem = new SaveSystem();
            _player = _saveSystem.LoadPlayer();
            
            if (_player == null)
                SceneManager.LoadScene("Registration");
            else
                SceneManager.LoadScene("MainMenu");
        }
        
        private void RegisterGlobalServices()
        {
            IDailyChallengeService dailyChallengeService;
            
            if (Debug.isDebugBuild) 
                dailyChallengeService = new Services.Mocks.DailyChallengeService();
            else
                dailyChallengeService = new DailyChallengeService();
            
            ServiceLocator.RegisterService(dailyChallengeService);
        }
        
        void OnApplicationQuit() 
        {
            _sessionEndTime = DateTime.Now;
            
            TimeSpan timeDifference = 
                _sessionEndTime.Subtract(_sessionStartTime);

            if (_player != null)
            {
                _player.lastSessionDuration = timeDifference;
                _saveSystem.SavePlayer(_player);
            }
        }
    }
}