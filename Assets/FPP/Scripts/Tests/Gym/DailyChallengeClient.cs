using UnityEngine;
using FPP.Scripts.Services;

namespace FPP.Scripts.Tests.Gym
{
    public class DailyChallengeClient : MonoBehaviour
    {
        private IDailyChallengeService _dailyChallengeService; 
        void Start()
        {
            _dailyChallengeService = new Services.Mocks.DailyChallengeService();
            _dailyChallengeService.GetDailyChallenges();
        }
    }
}