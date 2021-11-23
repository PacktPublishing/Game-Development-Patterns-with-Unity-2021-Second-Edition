using UnityEngine;
using FPP.Scripts.Core;
using FPP.Scripts.Enums;
using FPP.Scripts.Systems;
using FPP.Scripts.Patterns;

namespace FPP.Scripts.Controllers
{
    public class RaceController : MonoBehaviour
    {
        private Player _player;
        private SaveSystem _saveSystem;
        private TrackController _trackController;
        private GameObject _trackControllerGameObject;
        
        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.END, LoadNextTrack);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.END, LoadNextTrack);
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
                    _trackController.InitTrack(_player.currentTrack);
        }

        private void LoadNextTrack()
        {
            int nextTrackIndex = _player.currentTrack + 1; // Incrementing the current track index assumes that the order of the tracks will not change and stay consistent
                
            if (IsTrackInList(nextTrackIndex))
            {
                _player.currentTrack = nextTrackIndex;
                _saveSystem.SavePlayer(_player);
                
                if (_trackController)
                    _trackController.LoadNextTrack(_player.currentTrack);
            }
            else
            {
                Debug.LogError("No more tracks available!");
                
                // TODO: When no more tracks available in the track list, display circuit ending screen.  
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