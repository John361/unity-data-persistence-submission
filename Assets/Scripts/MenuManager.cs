using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance;
    private PlayerPersistor playerPersistor;
    private PlayerData playerData;
    private MenuCanvasController menuCanvasController;

    private void Awake()
    {
        if (MenuManager.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        this.menuCanvasController = GameObject.Find("Canvas").GetComponent<MenuCanvasController>();
        MenuManager.instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.LoadPlayer();
    }

    private void LoadPlayer()
    {
        this.playerPersistor = new PlayerPersistor();

        try
        {
            this.playerData = this.playerPersistor.Load();
        }
        catch (System.IO.FileNotFoundException)
        {
            this.playerData = new PlayerData
            {
                name = "",
                bestScore = 0
            };
        }

        this.menuCanvasController.SetBestScore(this.playerData.bestScore);
        this.menuCanvasController.SetPlayerName(this.playerData.name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

        string inputPlayerName = this.menuCanvasController.GetPlayerName();

        if (this.playerData.name != inputPlayerName)
        {
            this.playerData.bestScore = 0;
        }

        this.playerData.name = inputPlayerName;
        this.playerPersistor.Save(this.playerData);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public static MenuManager GetInstance()
    {
        return MenuManager.instance;
    }

    public static PlayerData GetPlayer()
    {
        return MenuManager.GetInstance().playerData;
    }
}
