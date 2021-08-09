using TMPro;
using UnityEngine;
using FPP.Scripts.Core;
using FPP.Scripts.Systems;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.UI
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
        
        void Start()
        {
            DisplayBuildNumber();
            DisplayPlayerInfo();
        }

        public void Play()
        {
            SceneManager.LoadScene("RaceTrack");
        }

        public void Exit()
        {
            Application.Quit();
        }

        private void DisplayBuildNumber()
        {
            versionNumber.text = versionPrefix + versionFile.text;
        }

        private void DisplayPlayerInfo()
        {
            SaveSystem saveSystem = new SaveSystem();
            Player player = saveSystem.LoadPlayer();

            if (player != null)
            {
                playerName.text = player.playerName;
                sessionDuration.text = player.lastSessionDuration.ToString(); // TODO: format the string to present HH:MM:SS
            }
        }
    }
}