using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingView : IView
{
    public void CancelButton()
    {
        InGameUIManager.Instance.ReturnMainMenu();
    }
}
