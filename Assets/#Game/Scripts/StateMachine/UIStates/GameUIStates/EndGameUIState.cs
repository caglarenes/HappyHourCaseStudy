using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUIState : IUIState
{
    Team _winner;

    public EndGameUIState(Team winner)
    {
        _winner = winner;
    }

    public void OnEnter()
    {
        InGameUIManager.Instance.CloseAllScreens();
        InGameUIManager.Instance.EndGameView.ChangeVisibility(true);

        if(_winner == GameManager.Instance.PlayerTeam)
        {
            InGameUIManager.Instance.EndGameView.ShowWinnerScreen();
        }
        else
        {
            InGameUIManager.Instance.EndGameView.ShowLoserScreen();
        }
    }

    public void OnExit()
    {
        
    }

    public void UpdateState()
    {
        
    }

}
