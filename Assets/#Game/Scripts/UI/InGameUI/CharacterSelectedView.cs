using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectedView : IView
{
    public void Deselect()
    {
        InGameUIManager.Instance.Deselect();
    }
}
