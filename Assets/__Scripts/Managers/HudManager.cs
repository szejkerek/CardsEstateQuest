using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour 
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI nicknameText;
    [SerializeField] TextMeshProUGUI bombsLeftText;
    [SerializeField] Image difficultyIcon;

    private void Start()
    {
        UpdateHud();
    }

    public void UpdateHud()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        nicknameText.text = nickname;
        bombsLeftText.text = GameManager.Instance.Difficulty.NumberOfBombs.ToString();
        difficultyIcon.sprite = GameManager.Instance.Difficulty.Icon;
    }
}
