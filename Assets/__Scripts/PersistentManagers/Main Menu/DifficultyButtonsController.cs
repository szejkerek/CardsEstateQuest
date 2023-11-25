using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages difficulty buttons and the start panel.
/// </summary>
public class DifficultyButtonsController : Singleton<DifficultyButtonsController>
{
    [SerializeField] GameObject startPanel;

    [SerializeField] Transform buttonContainer;
    [SerializeField] DifficultyButton buttonPrefab;

    List<DifficultyButton> difficultyButtons = new List<DifficultyButton>();

    bool startPanelAnimated = false;
    Vector3 initScale;

    private void Start()
    {
        startPanel.SetActive(false);
        initScale = startPanel.transform.localScale;
    }

    /// <summary>
    /// Generates difficulty buttons based on the provided difficulties.
    /// </summary>
    public void GenerateLevelButtons(CrudList<Difficulty> difficulties)
    {
        for (int i = 0; i < difficulties.Count; i++)
        {
            DifficultyButton button = Instantiate(buttonPrefab, buttonContainer);
            button.SetDifficulty(difficulties.GetItem(i));
            difficultyButtons.Add(button);
        }
    }

    /// <summary>
    /// Manages the selected difficulty button.
    /// </summary>
    public void ManageSelectedButton(DifficultyButton selectedButton)
    {
        foreach (var button in difficultyButtons)
        {
            button.DeselectButton();
        }
        selectedButton.SelectButton();

        GameManager.Instance.SetDifficulty(selectedButton.Difficulty);

        AnimateShowStartPanel();
    }

    private void AnimateShowStartPanel()
    {
        if (startPanelAnimated)
            return;

        startPanel.transform.localScale = Vector3.zero;
        startPanel.SetActive(true);
        startPanel.transform.DOScale(initScale, 1f).SetEase(Ease.OutBounce);
        startPanelAnimated = true;
    }
}
