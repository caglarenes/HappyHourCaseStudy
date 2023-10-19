using System;
using UnityEngine;


public class GameStateController : ScopedSingleton<GameStateController>
{
    public StateMachineTest NetworkStateMachine;

    public IGameState currentState;
    public IUIState currentUIState;

    public string ActiveState = String.Empty;
    public string ActiveUIState = String.Empty;


    void Update()
    {
        currentState?.UpdateState();
        currentUIState?.UpdateState();
    }

    public void ChangeState(GameState newState)
    {
        NetworkStateMachine.SetState(newState);
    }

    public void ChangeLocalState(IGameState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState.OnEnter();

        ActiveState = currentState.GetType().Name;
    }

    public void ChangeUIState(IUIState newState)
    {
        currentUIState?.OnExit();
        currentUIState = newState;
        currentUIState.OnEnter();

        ActiveUIState = currentUIState.GetType().Name;
    }
}
