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

            if (SelectionManager.Instance.TryGetSelectedWoodSource(out var selectedWoodSource))
            {

                SelectedCharacter.CollectWoodSource(selectedWoodSource);
                return;
            };

            if (SelectionManager.Instance.TryGetSelectedCharacter(out var selectedCharacter))
            {
                SelectedCharacter = selectedCharacter;
                return;
            };

            if (SelectionManager.Instance.TryGetSelectedMapPoint(out var selectedPoint))
            {
                SelectedCharacter.MoveToPosition(selectedPoint);
                return;
            };
        }
    }
}
