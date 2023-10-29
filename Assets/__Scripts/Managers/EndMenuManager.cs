using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneLoader.Instance.LoadScene(SceneEnum.MainMenu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
