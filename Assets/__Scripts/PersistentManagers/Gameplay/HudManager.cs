using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the HUD elements and information display.
/// </summary>
public class HudManager : MonoBehaviour
{
    [Header("InfoPanel")]
    [SerializeField] TextMeshProUGUI nicknameText;
    [SerializeField] TextMeshProUGUI bombsLeftText;
    [SerializeField] Image difficultyIcon;

    private void Start()
    {
        SetInfoPanel();
    }

    /// <summary>
    /// Sets the information panel with player's nickname, bomb count, and difficulty icon.
    /// </summary>
    private void SetInfoPanel()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        nicknameText.text = nickname;
        bombsLeftText.text = GameManager.Instance.Difficulty.NumberOfBombs.ToString();
        difficultyIcon.sprite = GameManager.Instance.Difficulty.Icon;
    }

    /// <summary>
    /// Updates the bomb count display in the HUD.
    /// </summary>
    public void UpdateBombCount()
    {
        bombsLeftText.text = GameplayManager.Instance.BombCount.ToString();
    }
}
