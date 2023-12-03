using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MainMenuManager : Singleton<MainMenuManager>
{
    DifficultyButtonsController buttonController;
    [SerializeField] private TMP_InputField nicknameInput;

    List<Difficulty> difficulties = new List<Difficulty>();
    [SerializeField] AssetLabelReference difficultyLabel;

    private void Start()
    {
        buttonController = GetComponent<DifficultyButtonsController>();

        LoadDifficulties();
        buttonController.GenerateLevelButtons(difficulties);
    }

    private void LoadDifficulties()
    {
        List<IDifficulty> tempDifficulties = new List<IDifficulty>();
        tempDifficulties = DefaultLoader<IDifficulty>.Load(difficultyLabel);
        foreach (var difficulty in tempDifficulties)
        {
            Difficulty tempDiff = new Difficulty(difficulty);
            if (tempDiff.IsValid())
            {
                difficulties.Add(tempDiff);
            }
        }
    }

    public void StartGame()
    {
        string nickname = nicknameInput.text;
        if (string.IsNullOrEmpty(nickname))
        {
            Debug.LogWarning("Nickname is empty");
            return;
        }
        PlayerPrefs.SetString("nickname", nickname);

        SceneLoader.Instance.LoadScene(SceneEnum.Gameplay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
