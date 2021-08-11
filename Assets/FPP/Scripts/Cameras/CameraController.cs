using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using FPP.Scripts.Ingredients.Bike;

namespace FPP.Scripts.Cameras
{
    public class CameraController : Observer
    {
        public BikeController bikeController;

        private GameObject _startCamera;
        private GameObject _followCamera;
        private GameObject _crashCamera;
        private GameObject _finishCamera;

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, DisplayStartCamera);
            RaceEventBus.Subscribe(RaceEventType.FINISH, DisplayFinishCamera);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, DisplayStartCamera);
            RaceEventBus.Unsubscribe(RaceEventType.FINISH, DisplayFinishCamera);
        }

        void Start()
        {
            DisplayFinishCamera();
        }

        private void DisplayStartCamera()
        {
            Debug.Log("Start Camera");
        }

        private void DisplayFinishCamera()
        {
            _finishCamera = Instantiate(Resources.Load("FinishCamera", typeof(GameObject))) as GameObject;
            if (_finishCamera)
                _finishCamera.transform.position = bikeController.transform.position + new Vector3(0.0f, 0.5f, -2.5f);
        }

        public override void Notify(Subject subject)
        {
            Debug.Log("Observer");
        }
    }
}