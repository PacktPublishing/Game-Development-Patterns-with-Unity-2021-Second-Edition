using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyState : IGameState
{
    public void LoadState(GameStateContext gameContext)
    {
        gameContext.SetState(new RaceState());
        gameContext.LoadContextScene(LoadLobby);
        
        Debug.Log("LobbyState loaded!");
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Additive);
    }
}