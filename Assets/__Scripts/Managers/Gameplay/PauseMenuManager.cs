using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneLoader.Instance.LoadScene(SceneEnum.MainMenu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
