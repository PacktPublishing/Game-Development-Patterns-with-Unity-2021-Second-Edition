using FPP.Scripts.Systems;
using FPP.Scripts.Patterns;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        void Start()
        {
            InitGame();
        }

        private void InitGame()
        {
            SaveSystem saveSystem = new SaveSystem();
            Player player = saveSystem.LoadPlayer();

            if (player == null)
                SceneManager.LoadScene("Registration");
            else
                SceneManager.LoadScene("MainMenu");
        }
    }
}