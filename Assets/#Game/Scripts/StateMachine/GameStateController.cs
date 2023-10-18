using System;

public class GameStateController : ScopedSingleton<GameStateController>
{
    public IGameState currentState;
    public IUIState currentUIState;

    public string ActiveState = String.Empty;
    public string ActiveUIState = String.Empty;


    void Update()
    {
        currentState?.UpdateState();
        currentUIState?.UpdateState();
    }
    public void ChangeState(IGameState newState)
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
