using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingUIState : IUIState
{

    public void OnEnter()
    {
        InGameUIManager.Instance.CloseAllScreens();
        InGameUIManager.Instance.WaitingView.ChangeVisibility(true);
    }

    public void OnExit()
    {
        
    }

    public void UpdateState()
    {
        
    }

}
