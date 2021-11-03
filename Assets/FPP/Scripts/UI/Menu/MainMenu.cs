using TMPro;
using UnityEngine;
using FPP.Scripts.Core;
using FPP.Scripts.Systems;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.UI.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Player Stats")]
        public TMP_Text playerName;
        public TMP_Text sessionDuration;
        
        [Header("Build Version")]
        public string versionPrefix;
        public TextAsset versionFile;
        public TMP_Text versionNumber;

        private Player _player;
        private SaveSystem _saveSystem;

        void Awake()
        {
            _saveSystem = new SaveSystem();
            _player = _saveSystem.LoadPlayer();
        }

        void Start()
        {
            DisplayPlayerInfo();
            DisplayVersionNumber();
        }

        public void Play()
        {
            SceneManager.LoadScene("RaceTrack");
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Reset()
        {
            _saveSystem.DeleteSave();
            SceneManager.LoadScene("Registration");
        }

        private void DisplayVersionNumber()
        {
            versionNumber.text = versionPrefix + versionFile.text;
        }

        private void DisplayPlayerInfo()
        {
            if (_player != null)
            {
                playerName.text = _player.playerName;
                sessionDuration.text = _player.lastSessionDuration.ToString(); // TODO: format the string to present HH:MM:SS
            }
        }
    }
}