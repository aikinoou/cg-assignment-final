using DialogueEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int acceptCount = 0;
    public int cutCount = 0;

    [HideInInspector] public int sceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void OnTransitionComplete()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
