using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//controleaza logica generala a jocului și interacțiunea cu utilizatorul.

    public bool playerCanMove = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
       
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        instance.playerCanMove = true;
    }

    void Start()
    {
        instance.playerCanMove = true;
        // menu
        UIManager.instance.ShowMenu();
        // pausa pana nu sa apasa butonul play
        instance.PauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape")){
            instance.PauseGame();
            UIManager.instance.ShowMenu();
        }
    }

    public void ResumeGameplay()
    {
        instance.ResumeGame();
        UIManager.instance.HideMenu();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }

}
