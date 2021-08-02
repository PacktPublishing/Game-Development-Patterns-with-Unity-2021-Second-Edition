using UnityEngine;
using UnityEngine.UI;
using FPP.Scripts.Systems;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.UI
{ 
    public class RegistrationWindow : MonoBehaviour
    {
        public void RegisterPlayer(InputField playerName)
        {
            SaveSystem saveSystem = new SaveSystem();
            Player player = saveSystem.LoadPlayer();

            if (player == null)
            {
                player = new Player();
                player.playerName = playerName.text;
                
                saveSystem.SavePlayer(player);
            }
            
            SceneManager.LoadScene("MainMenu"); // TODO: New player should be redirected to intro cinematic
        }
    }
}