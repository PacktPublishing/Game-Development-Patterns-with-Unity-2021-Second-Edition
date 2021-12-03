using UnityEngine;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using System.Collections.Generic;
using FPP.Scripts.Ingredients.Track;

namespace FPP.Scripts.Controllers
{
    public class GymController : MonoBehaviour
    {
        public List<RaceTrack> tracks = new();
        
        private TrackController _trackController;
        private GameObject _trackControllerGameObject;
        
        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.RESTART, RestartRace);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.RESTART, RestartRace);
        }
        
        private void Awake()
        {
            _trackControllerGameObject = Instantiate(Resources.Load("TrackController", typeof(GameObject))) as GameObject;

            if (_trackControllerGameObject != null)
                _trackController = _trackControllerGameObject.GetComponent<TrackController>();

            if (_trackController)
            {
                _trackController.tracks = new List<RaceTrack>(tracks);
            }
        }

        private void Start()
        {
            if (_trackController)
                _trackController.SpawnTrack(0, false);
        }

        private void RestartRace()
        {
            if (_trackController)
                _trackController.SpawnTrack(0, false);
        }
    }
}