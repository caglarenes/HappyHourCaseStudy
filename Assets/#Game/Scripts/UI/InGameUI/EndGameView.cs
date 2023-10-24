using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameView : IView
{
    public void ReturnMainMenu()
    {
        InGameUIManager.Instance.ReturnMainMenu();
    }
}
