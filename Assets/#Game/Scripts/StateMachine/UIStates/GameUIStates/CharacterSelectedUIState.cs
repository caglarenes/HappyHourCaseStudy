using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectedUIState : IUIState
{
    public Character SelectedCharacter;

    public CharacterSelectedUIState(Character selectedCharacter)
    {
        SelectedCharacter = selectedCharacter;
    }

    public void OnEnter()
    {
        InGameUIManager.Instance.CloseAllScreens();
        InGameUIManager.Instance.CharacterSelectedView.ChangeVisibility(true);
    }

    public void OnExit()
    {

    }

    public void UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Character Order Pos 1");
            if (SelectionManager.Instance.TryGetSelectedMapPoint(out var selectedPoint))
            {
                Debug.Log("Character Order Pos 2");
                SelectedCharacter.MovePosition(selectedPoint);
            };
        }
    }
}
