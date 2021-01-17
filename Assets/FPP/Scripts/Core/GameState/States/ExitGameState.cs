using UnityEngine;

public class ExitGameState : IGameState
{
    public void LoadState(GameStateContext gameContext)
    {
        Debug.Log("ExitGameState loaded!");
    }
}