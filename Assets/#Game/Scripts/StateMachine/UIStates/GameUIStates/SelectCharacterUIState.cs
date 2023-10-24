using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterUIState : IUIState
{
    public void OnEnter()
    {
        InGameUIManager.Instance.CloseAllScreens();
        InGameUIManager.Instance.SelectCharacterView.ChangeVisibility(true);
    }

    public void OnExit()
    {

    }

    public void UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SelectionManager.Instance.TryGetSelectedCharacter(out var selectedCharacter))
            {
                GameStateController.Instance.ChangeUIState(new CharacterSelectedUIState(selectedCharacter));
            };
        }

    }
}
