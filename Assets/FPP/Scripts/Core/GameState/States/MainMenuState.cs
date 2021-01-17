using UnityEngine;

public class MainMenuState : IGameState
{
    public void LoadState(GameStateContext gameContext)
    {
        gameContext.SetState(new LobbyState());
        gameContext.LoadContextScene(LoadMenu);
        
        Debug.Log("MainMenuState loaded!");
    }

    public void LoadMenu()
    {
        Object prefab = Resources.Load("MainMenu");
        
        if (prefab != null)
        {
            GameObject raceManager = GameObject.Instantiate(prefab) as GameObject;
        }
        else
        {
            Debug.LogWarning("No MainMenu prefab found!");
        }
    }
}