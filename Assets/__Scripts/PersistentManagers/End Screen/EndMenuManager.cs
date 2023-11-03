using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the end menu and related functionality.
/// </summary>
public class EndMenuManager : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public GameObject menuCanvas;

    private void Awake()
    {
        Hide();
    }

    /// <summary>
    /// Shows the end menu based on whether the player won or lost.
    /// </summary>
    public void Show(bool didWin)
    {
        menuCanvas.SetActive(true);

        if (didWin)
        {
            endText.text = "You Win!";
        }
        else
        {
            endText.text = "You Lose!";
        }
    }

    /// <summary>
    /// Hides the end menu.
    /// </summary>
    public void Hide()
    {
        menuCanvas.SetActive(false);
    }

    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public void LoadMenu()
    {
        SceneLoader.Instance.LoadScene(SceneEnum.MainMenu);
    }

    /// <summary>
    /// Quits the game application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
