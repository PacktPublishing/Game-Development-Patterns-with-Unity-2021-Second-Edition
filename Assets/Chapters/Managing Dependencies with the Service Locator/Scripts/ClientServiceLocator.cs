using UnityEngine;

namespace Chapter.ServiceLocator
{
    public class ClientServiceLocator : MonoBehaviour
    {
        void Start()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            ILoggerService logger = new LoggerMock();
            ServiceLocator.RegisterService(logger);

            IAnalyticsService analytics = new Analytics();
            ServiceLocator.RegisterService(analytics);
        }

        void OnGUI()
        {
            GUILayout.Label("Review output in console");

            if (GUILayout.Button("Log event"))
            {
                ILoggerService logger = ServiceLocator.GetService<ILoggerService>();
                logger.Log("Hello World!");
            }

            if (GUILayout.Button("Send analytics"))
            {
                IAnalyticsService analytics = ServiceLocator.GetService<IAnalyticsService>();
                analytics.SendEvent("Hello World!");
            }
        }
    }
}
