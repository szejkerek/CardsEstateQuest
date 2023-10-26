using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonsController : Singleton<DifficultyButtonsController>
{
    [SerializeField] GameObject startPanel;

    [SerializeField] Transform buttonContainer;
    [SerializeField] DifficultyButton buttonPrefab;

    List<DifficultyButton> difficultyButtons = new List<DifficultyButton>();

    private void Start()
    {
        startPanel.SetActive(false);
    }

    public void GenerateLevelButtons(CrudList<IDifficulty> difficulties)
    {
        for (int i = 0; i < difficulties.Count; i++)
        {
            DifficultyButton button = Instantiate(buttonPrefab, buttonContainer);
            button.SetDifficulty(difficulties.GetItem(i));
            difficultyButtons.Add(button);
        }
    }

    public void ManageSelectedButton(DifficultyButton selectedButton)
    {
        foreach (var button in difficultyButtons)
        {
            button.DeselectButton();
        }
        selectedButton.SelectButton();

        GameManager.Instance.SetDifficulty(selectedButton.Difficulty);
        startPanel.SetActive(true);
    }
}
