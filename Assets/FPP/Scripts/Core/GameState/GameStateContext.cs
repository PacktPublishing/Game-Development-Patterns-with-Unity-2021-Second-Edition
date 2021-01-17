using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateContext: MonoBehaviour
{
    private IGameState m_CurrentState;
    public string ContextSceneName { get; set; } = "Context";
    
    private void Awake()
    {
        m_CurrentState = new InitGameState();
    }

    public void SetState(IGameState gameState)
    {
        m_CurrentState = gameState;
    }

    public void LoadState()
    {
        m_CurrentState.LoadState(this);
    }

    public void LoadContextScene(System.Action callBack)
    {
        StartCoroutine(LoadSceneAsync(ContextSceneName, callBack));
    }
    
    private IEnumerator LoadSceneAsync(string sceneName, System.Action callBack)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        while (!asyncLoad.isDone)
        { 
            yield return null;
        }
        
        callBack();
    }
}