using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppNavigator : MonoBehaviour
{
    public void RestartGame()
    {   
        SceneLoader.Instance.LoadScene(SceneEnum.Gameplay);
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
