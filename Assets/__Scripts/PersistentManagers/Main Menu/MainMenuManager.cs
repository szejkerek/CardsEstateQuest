using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Manages the main menu and difficulty selection.
/// </summary>
public class MainMenuManager : Singleton<MainMenuManager>
{
    DifficultyButtonsController buttonController;
    [SerializeField] private TMP_InputField nicknameInput;

    CrudList<Difficulty> difficulties = new CrudList<Difficulty>();
    [SerializeField] AssetLabelReference difficultyLabel;

    private void Start()
    {
        buttonController = GetComponent<DifficultyButtonsController>();

        LoadDifficulties();
        buttonController.GenerateLevelButtons(difficulties);
    }

    /// <summary>
    /// Loads difficulties from Addressables and filters valid ones to populate the list.
    /// </summary>
    private void LoadDifficulties()
    {
        CrudList<IDifficulty> tempDifficulties = new CrudList<IDifficulty>();
        tempDifficulties.LoadList(difficultyLabel);
        foreach (var difficulty in tempDifficulties)
        {
            Difficulty tempDiff = new Difficulty(difficulty);
            if (tempDiff.IsValid())
            {
                difficulties.AddItem(tempDiff);
            }
        }
    }

    /// <summary>
    /// Starts the game with the provided nickname and loads the gameplay scene.
    /// </summary>
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

    /// <summary>
    /// Quits the game application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
