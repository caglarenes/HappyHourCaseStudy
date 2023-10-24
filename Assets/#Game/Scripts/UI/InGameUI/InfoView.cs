using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoView : MonoBehaviour
{
    public TMP_Text Player1ScoreText;
    public TMP_Text Player2ScoreText;

    [SerializeField]
    private GameObject Player1Info;
    [SerializeField]
    private GameObject Player2Info;

    GameManager gameManager;

    public void Setup()
    {
        gameManager = GameManager.Instance;

        gameManager.OnPlayer1ScoreChanged.AddListener(UpdateText);
        gameManager.OnPlayer2ScoreChanged.AddListener(UpdateText);

        SetupPlayerTeeamInfo();
    }

    private void SetupPlayerTeeamInfo()
    {
        if (GameManager.Instance.PlayerTeam == Team.TeamA)
        {
            Player1Info.SetActive(true);
        }
        else
        {
            Player2Info.SetActive(true);
        }
    }

    void UpdateText()
    {
        Player1ScoreText.text = FormatScoreText(gameManager.Player1Score);
        Player2ScoreText.text = FormatScoreText(gameManager.Player2Score);
    }

    string FormatScoreText(int score)
    {
        return $"{score} / {gameManager.Settings.EndGameScore}";
    }
}
