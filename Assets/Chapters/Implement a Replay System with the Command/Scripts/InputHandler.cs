using UnityEngine;

namespace Chapter.Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private bool _isReplaying;
        private bool _isRecording;
        private Command _buttonA, _buttonD, _buttonW;
        private BikeController _bikeController;

        void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = FindObjectOfType<BikeController>();

            _buttonA = new TurnLeft(_bikeController);
            _buttonD = new TurnRight(_bikeController);
            _buttonW = new ToggleTurbo(_bikeController);
        }

        void Update()
        {
            if (!_isReplaying)
            {
                if (Input.GetKeyUp(KeyCode.A)) _invoker.ExecuteCommand(_buttonA);
                
                if (Input.GetKeyUp(KeyCode.D)) _invoker.ExecuteCommand(_buttonD);
                
                if (Input.GetKeyUp(KeyCode.W)) _invoker.ExecuteCommand(_buttonW);
                
                // Record Commands
                if (Input.GetKeyUp(KeyCode.F1))
                {
                    _bikeController.ResetPosition();
                    _isReplaying = false;
                    _isRecording = !_isRecording;
                    _invoker.Record();
                }
            }

            // Replay Commands
            if (Input.GetKeyUp(KeyCode.F2))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
                _isReplaying = !_isReplaying;
                _invoker.Replay();
            }
        }

        void OnGUI()
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(10, 10, 500, 20), "Recording (F1 to record): " + _isRecording.ToString());
            GUI.Label(new Rect(10, 30, 500, 20), "Replaying (F2 to replay): " + _isReplaying.ToString());
        }
    }
}