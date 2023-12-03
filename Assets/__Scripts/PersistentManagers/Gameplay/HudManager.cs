using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour 
{
    [Header("InfoPanel")]
    [SerializeField] TextMeshProUGUI nicknameText;
    [SerializeField] Image difficultyIcon;

    private void Start()
    {
        SetInfoPanel();
    }

    private void SetInfoPanel()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        nicknameText.text = nickname;
        difficultyIcon.sprite = GameManager.Instance.Difficulty.Icon;
    }
}
