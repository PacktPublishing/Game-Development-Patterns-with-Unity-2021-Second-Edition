using UnityEngine;

public class InitGameState : IGameState
{
    public void LoadState(GameStateContext gameContext)
    {
        gameContext.SetState(new MainMenuState());
        gameContext.LoadState();
        
        Debug.Log("InitGameState loaded!");
    }
}