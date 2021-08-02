using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        public string versionPrefix;
        public TextAsset versionFile;
        public TMP_Text versionNumber;

        void Start()
        {
            DisplayVersion();
        }

        public void Play()
        {
            SceneManager.LoadScene("Track");
        }

        public void Exit()
        {
            Application.Quit();
        }

        private void DisplayVersion()
        {
            versionNumber.text = versionPrefix + versionFile.text;
        }
    }
}
