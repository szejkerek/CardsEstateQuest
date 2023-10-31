using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour 
{
    [Header("InfoPanel")]
    [SerializeField] TextMeshProUGUI nicknameText;
    [SerializeField] TextMeshProUGUI bombsLeftText;
    [SerializeField] Image difficultyIcon;

    private void Start()
    {
        UpdateInfoPanel();
    }

    public void UpdateInfoPanel()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        nicknameText.text = nickname;
        bombsLeftText.text = GameManager.Instance.Difficulty.NumberOfBombs.ToString();
        difficultyIcon.sprite = GameManager.Instance.Difficulty.Icon;
    }
}
