using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [SerializeField] private TMP_InputField nicknameInput;
    public void StartGame()
    {
        string nickname = nicknameInput.text;
        if (string.IsNullOrEmpty(nickname))
        {
            Debug.LogWarning("Nickname is empty");
            return;
        }
        PlayerPrefs.SetString("nickname", nickname);

        SceneManager.LoadSceneAsync(1);
    }
}
