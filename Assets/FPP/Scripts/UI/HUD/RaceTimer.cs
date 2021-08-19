using UnityEngine;
using UnityEngine.UI;

namespace FPP.Scripts.UI.HUD
{
    public class RaceTimer : MonoBehaviour
    {
        public Text timer;

        private float _minutes;
        private float _seconds;
        private float _fraction;
        private bool _isRunning;
        private float _currentTime;

        public void StartTimer()
        {
            _isRunning = true;
        }

        public void PauseTimer()
        {
            _isRunning = !_isRunning;
        }

        public void StopTimer()
        {
            _isRunning = false;
        }

        void FixedUpdate()
        {
            if (_isRunning)
            {
                _currentTime += Time.deltaTime;
                _minutes = _currentTime / 60;
                _seconds = _currentTime % 60;
                _fraction = _currentTime * 1000;
                _fraction = _fraction % 1000;
                timer.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
            }
        }
    }
}