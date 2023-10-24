using System;
using UnityEngine;


public class CharacterStateController : MonoBehaviour
{
    public CharacterStateMachine NetworkStateMachine;

    public ICharacterState currentState;

    public string ActiveState = String.Empty;


    void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(CharacterState newState)
    {
        NetworkStateMachine.SetState(newState);
    }

    public void ChangeLocalState(ICharacterState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState.OnEnter();

        ActiveState = currentState.GetType().Name;
    }
}
