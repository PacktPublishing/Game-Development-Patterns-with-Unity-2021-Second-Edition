using System;
using UnityEngine;
using UnityEngine.UI;
using FPP.Scripts.Core;
using FPP.Scripts.Systems;
using UnityEngine.SceneManagement;

namespace FPP.Scripts.UI.Window
{ 
    public class RegistrationWindow : MonoBehaviour
    {
        [SerializeField] private string defaultPlayerName;
        
        public void RegisterPlayer(InputField playerName)
        {
            SaveSystem saveSystem = new SaveSystem();
            Player player = saveSystem.LoadPlayer();
            
            if (player == null)
            {
                player = new Player();

                if (String.IsNullOrEmpty(playerName.text))
                    player.playerName = defaultPlayerName;
                else
                    player.playerName = playerName.text;

                saveSystem.SavePlayer(player);
            }
            
            SceneManager.LoadScene("MainMenu"); // TODO: New player should be redirected to intro cinematic
        }
    }
}