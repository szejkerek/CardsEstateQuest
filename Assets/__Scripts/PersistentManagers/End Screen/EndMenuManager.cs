using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenuManager : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public GameObject menuCanvas;

    private void Awake()
    {
        Hide();
    }

    public void Show(bool didWin)
    {
        menuCanvas.SetActive(true);

        if(didWin)
        {
            endText.text = "You Win!";
        }
        else
        {
            endText.text = "You Lose!";
        }
    }

    public void Hide()
    {
        menuCanvas.SetActive(false);
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
