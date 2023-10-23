using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] DifficultySO m_DifficultySO;
    [Header("UI")]
    [SerializeField] TextMeshProUGUI nicknameText;
    [SerializeField] TextMeshProUGUI bombsLeftText;
    [SerializeField] Image difficultyIcon;

    private void Awake()
    {
        UpdateHud();
    }

    public void UpdateHud()
    {
        string nickname = PlayerPrefs.GetString("nickname");
        nicknameText.text = nickname;

        bombsLeftText.text = m_DifficultySO.NumberOfBombs.ToString();

        difficultyIcon.sprite = m_DifficultySO.Icon;
    }
}
