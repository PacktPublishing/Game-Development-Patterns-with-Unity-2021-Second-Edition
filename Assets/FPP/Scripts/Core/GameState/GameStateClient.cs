using UnityEngine;

public class GameStateClient : MonoBehaviour
{
    private GameStateContext m_GameContext;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_GameContext = gameObject.AddComponent<GameStateContext>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_GameContext.LoadState();
        }
    }
}
