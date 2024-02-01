using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppNavigator : MonoBehaviour
{
    public void RestartGame()
    {   
        SceneLoader.Instance.LoadScene(SceneConstants.Gameplay);
    }

    public void LoadMenu()
    {
        SceneLoader.Instance.LoadScene(SceneConstants.Main_Menu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
