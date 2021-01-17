using System;
using UnityEngine;

public class RaceManager : Singleton<RaceManager>
{
    private GameStateContext m_GameContext;
    
    public void StartRace()
    {

    }

    public void CancelRace()
    {

    }

    public void EndRace()
	{

	}

    public void LoadRaceState()
    {
        m_GameContext.LoadState();
    }
    
    public void LoadRaceState(IGameState gameState)
    {
        m_GameContext.SetState(gameState);
        m_GameContext.LoadState();
    }
}