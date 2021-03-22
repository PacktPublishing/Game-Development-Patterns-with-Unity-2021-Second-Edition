using UnityEngine;

namespace Chapter.ServiceLocator
{
    public class LoggerMock: ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log("Mock:" + message);
        }
    }
}
