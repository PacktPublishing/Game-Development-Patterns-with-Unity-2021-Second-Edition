public class GameManager : Singleton<GameManager>
{
    private GameStateContext _gameContext; 
    
    public GameStateContext GameStateContext
    {
        get { return _gameContext; }
    }
    
    private void Start()
    {
        StartSession();
    }

    private void StartSession()
    {
        _gameContext = gameObject.AddComponent<GameStateContext>();
        _gameContext.LoadState();
    }

    public void StopSession()
    {
        //m_GameContext.SetState(IGameState );
        //m_GameContext.LoadState();
    }
}