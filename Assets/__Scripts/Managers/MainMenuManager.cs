using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MainMenuManager : Singleton<MainMenuManager>
{
    DifficultyButtonsController buttonController;
    [SerializeField] private TMP_InputField nicknameInput;

    CrudList<IDifficulty> difficulties = new CrudList<IDifficulty>();
    [SerializeField] AssetLabelReference difficultyLabel;

    private void Start()
    {
        buttonController = GetComponent<DifficultyButtonsController>();

        difficulties.LoadList(difficultyLabel);

        buttonController.GenerateLevelButtons(difficulties);
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
}
