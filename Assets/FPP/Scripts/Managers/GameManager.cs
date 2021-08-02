using UnityEngine.SceneManagement;

namespace Nerdtron.BladeRacer.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        void Start()
        {
            InitGame();
        }

        private void InitGame()
        {
            Player player = new Player();
            // TODO: Check if player has a save file, if not move him to the registration scene
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}