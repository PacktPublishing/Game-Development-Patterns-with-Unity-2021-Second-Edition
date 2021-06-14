using UnityEngine;

namespace Chapter.ServiceLocator
{
    public class Analytics : IAnalyticsService
    {
        public void SendEvent(string eventName)
        {
            Debug.Log("Sent: " + eventName);
        }
    }
}