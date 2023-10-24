using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameView : IView
{
    [SerializeField]
    GameObject _winnerText;
    [SerializeField]
    GameObject _loserText;
    public void ReturnMainMenu()
    {
        InGameUIManager.Instance.ReturnMainMenu();
    }

    public void ShowWinnerScreen()
    {
        ShowEndGameText(true);
    }

    public void ShowLoserScreen()
    {
        ShowEndGameText(false);
    }

    void ShowEndGameText(bool isWinner)
    {
        _winnerText.SetActive(isWinner);
        _loserText.SetActive(!isWinner);
    }
}
