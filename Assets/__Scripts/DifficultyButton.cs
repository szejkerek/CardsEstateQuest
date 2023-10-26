using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] Image image;

    IDifficulty difficulty;

    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
        SetTitle(difficulty.Name);
        SetIcon(difficulty.Icon);
    }

    void SetTitle(string text)
    {
        title.text = text;
    }

    void SetIcon(Sprite icon)
    {
        image.sprite = icon;
    }
}
