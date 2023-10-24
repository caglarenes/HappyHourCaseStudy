using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchUIState : IUIState
{
    public void OnEnter()
    {
        MainMenuUIManager.Instance.CloseAllScreens();
        MainMenuUIManager.Instance.SearchView.ChangeVisibility(true);
    }

    public void OnExit()
    {
        
    }

    public void UpdateState()
    {
        
    }

}
