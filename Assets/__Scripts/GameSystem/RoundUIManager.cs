using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class RoundUIManager : MonoBehaviour
{
    [SerializeField] GameObject roundUI;
    [SerializeField] GameObject endGameUI;
    [SerializeField] GameObject pauseMenuUI;

    [SerializeField] TMP_Text roundNumber;
    [SerializeField] TMP_Text activePlayerName;
    [SerializeField] TMP_Text activePlayerScore;
    [SerializeField] TMP_Text activePlayerWins;
    [SerializeField] TMP_Text endOfGameInfo;
    [SerializeField] TMP_Text role;

    private bool gameIsPaused  = false;

    private void Awake()
    {
        roundUI.SetActive(true);
        endGameUI.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && (roundUI.active || pauseMenuUI.active))
        {
            if(gameIsPaused) 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
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
    public void SetRoleText(string r)
    {
        role.text = r;
    }

    public void ShowEndGameUI()
    {
        roundUI.SetActive(false);
        endGameUI.SetActive(true);
    }
}

