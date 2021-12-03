using UnityEngine;
using FPP.Scripts.Core;
using FPP.Scripts.Enums;
using FPP.Scripts.Systems;
using FPP.Scripts.Patterns;

namespace FPP.Scripts.Controllers
{
    public class RaceController : MonoBehaviour
    {
        public bool isPlayerProgressionDisabled;
        
        private Player _player;
        private SaveSystem _saveSystem;
        private TrackController _trackController;
        private GameObject _trackControllerGameObject;
        
        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.END, EndRace);
            RaceEventBus.Subscribe(RaceEventType.REPLAY, ReplayRace);
            RaceEventBus.Subscribe(RaceEventType.RESTART, RestartRace);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.END, EndRace);
            RaceEventBus.Unsubscribe(RaceEventType.REPLAY, ReplayRace);
            RaceEventBus.Unsubscribe(RaceEventType.RESTART, RestartRace);
        }
        
        private void Awake()
        {
            _saveSystem = new SaveSystem();
            _player = _saveSystem.LoadPlayer();

            if (_player == null)
                _player = new Player();
            
            _trackControllerGameObject = Instantiate(Resources.Load("TrackController", typeof(GameObject))) as GameObject;

            if (_trackControllerGameObject != null)
                _trackController = _trackControllerGameObject.GetComponent<TrackController>();
        }

        private void Start()
        {
            if (_trackController)
                if (IsTrackInList(_player.currentTrack))
                    _trackController.SpawnTrack(_player.currentTrack, false);
        }

        private void RestartRace()
        {
            if (_trackController)
                _trackController.SpawnTrack(_player.currentTrack, false);
        }

        private void ReplayRace()
        {
            if (_trackController)
                _trackController.SpawnTrack(_player.currentTrack, true);
        }

        private void EndRace()
        {
            int nextTrackIndex = _player.currentTrack + 1; // Incrementing the current track index assumes that the order of the tracks will not change and stay consistent
                
            if (IsTrackInList(nextTrackIndex))
            {
                _player.currentTrack = nextTrackIndex;
                _saveSystem.SavePlayer(_player);
                
                if (_trackController)
                    _trackController.SpawnTrack(_player.currentTrack, false);
            }
            else
            {
                Debug.LogError("No more tracks available!");
                // TODO: When no more tracks available in the track list, load end of circuit menu.  
            }
        }

        private bool IsTrackInList(int trackIndex)
        {
            if (trackIndex >= 0 && trackIndex < _trackController.tracks.Count)
                return true;

            return false;
        }
    }
}