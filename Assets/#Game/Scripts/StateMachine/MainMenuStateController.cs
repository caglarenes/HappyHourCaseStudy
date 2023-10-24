using System;
using UnityEditor.Search;
using UnityEngine;


public class MainMenuStateController : ScopedSingleton<MainMenuStateController>
{
    public IUIState currentUIState;

    public string ActiveUIState = String.Empty;

    public void Start()
    {
        ChangeUIState(new SearchUIState());
    }


    void Update()
    {
        currentUIState?.UpdateState();
    }

    public void ChangeUIState(IUIState newState)
    {
        currentUIState?.OnExit();
        currentUIState = newState;
        currentUIState.OnEnter();

        ActiveUIState = currentUIState.GetType().Name;
    }
}
