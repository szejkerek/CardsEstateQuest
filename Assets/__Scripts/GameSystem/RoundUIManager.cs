using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class RoundUIManager : MonoBehaviour
{
    [SerializeField] GameObject roundUI;
    [SerializeField] GameObject EndGameUI;

    [SerializeField] TMP_Text roundNumber;
    [SerializeField] TMP_Text activePlayerName;
    [SerializeField] TMP_Text activePlayerScore;
    [SerializeField] TMP_Text activePlayerWins;

    [SerializeField] TMP_Text endOfGameInfo;

    private void Awake()
    {
        roundUI.SetActive(true);
        EndGameUI.SetActive(false);
    }

    public void SetRoundNumberText(string roundNumberText)
    {
        roundNumber.text = roundNumberText; 
    }

    public void SetActivePlayerNameText(string activePlayerNameText)
    {
        activePlayerName.text = activePlayerNameText;
    }

    public void SetAtivePlayerScoreText(string activePlayerScoreText)
    {
        activePlayerScore.text = activePlayerScoreText;
    }

    public void SetctivePlayerWinsText(string activePlayerWinsText)
    {
        activePlayerWins.text = activePlayerWinsText;
    }

    public void SetEndOfGameInfoText(string endOfGameInfoText)
    {
        endOfGameInfo.text = endOfGameInfoText;
    }

    public void ShowEndGameUI()
    {
        roundUI.SetActive(false);
        EndGameUI.SetActive(true);
    }
}

