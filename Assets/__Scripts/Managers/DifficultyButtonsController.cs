using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonsController : MonoBehaviour
{
    [SerializeField] Transform buttonContainer; 
    [SerializeField] DifficultyButton buttonPrefab;

    List<DifficultyButton> difficultyButtons = new List<DifficultyButton>();
    public void GenerateLevelButtons(CrudList<IDifficulty> difficulties)
    {
        for (int i = 0; i < difficulties.Count; i++)
        {
            DifficultyButton button = Instantiate(buttonPrefab, buttonContainer);
            button.SetDifficulty(difficulties.GetItem(i));
            difficultyButtons.Add(button);
        }
    }
}
