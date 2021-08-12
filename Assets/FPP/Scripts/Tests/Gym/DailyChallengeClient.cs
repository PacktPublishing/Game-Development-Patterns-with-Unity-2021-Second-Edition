using UnityEngine;
using FPP.Scripts.Patterns;
using FPP.Scripts.Services;

namespace FPP.Scripts.Tests.Gym
{
    public class DailyChallengeClient : MonoBehaviour
    {
        void Start()
        {
            ServiceLocator.GetService<IDailyChallengeService>().GetDailyChallenges();
        }
    }
}
