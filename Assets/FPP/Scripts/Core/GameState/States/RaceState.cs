using UnityEngine;

public class RaceState : IGameState
{
    public void LoadState(GameStateContext gameContext)
    {
        gameContext.SetState(new ExitGameState());
        gameContext.LoadContextScene(InitRaceManager);
        
        Debug.Log("RaceState loaded!");
    }

    public void InitRaceManager()
    {
        Object prefab = Resources.Load("RaceManager");
        
        if (prefab != null)
        {
            GameObject raceManager = GameObject.Instantiate(prefab) as GameObject;
        }
        else
        {
            Debug.LogWarning("No RaceManager prefab found!");
        }
    }
}