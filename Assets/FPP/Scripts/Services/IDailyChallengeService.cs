using System.Collections.Generic;

namespace FPP.Scripts.Services
{
    public interface IDailyChallengeService
    {
        List<Challenge> GetDailyChallenges();
    }
}