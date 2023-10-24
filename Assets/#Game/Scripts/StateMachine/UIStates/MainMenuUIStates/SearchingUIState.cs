using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingUIState : IUIState
{
    public void OnEnter()
    {
        MainMenuUIManager.Instance.CloseAllScreens();
        MainMenuUIManager.Instance.SearchingView.ChangeVisibility(true);

        PhotonManager.Instance.StartGame();
    }

    public void OnExit()
    {

    }

    public void UpdateState()
    {

    }

}
