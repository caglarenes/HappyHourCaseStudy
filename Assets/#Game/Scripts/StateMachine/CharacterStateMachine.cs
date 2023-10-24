using Fusion;
using UnityEngine;

public class CharacterStateMachine : NetworkBehaviour
{
    public Character Chacter;
    public CharacterNetworkStateMachine StateMachine;
    public CharacterStateController StateController;


    public override void Spawned()
    {
        StateMachine[CharacterState.Idle].OnEnter = (m, state) =>
        {
            StateController.ChangeLocalState(new IdleState(Chacter));
            Debug.Log($"Entered Idle State from {state}");
        };
        StateMachine[CharacterState.Idle].OnExit = (m, state) => { Debug.Log($"Left Idle State for {state}"); };

        StateMachine[CharacterState.Walk].OnEnter = (m, state) =>
        {
            StateController.ChangeLocalState(new MoveState(Chacter));
            Debug.Log($"Entered Walk State from {state}");
        };
        StateMachine[CharacterState.Walk].OnExit = (m, state) => { Debug.Log($"Left Walk State for {state}"); };

        StateMachine[CharacterState.MoveToCollect].OnEnter = (m, state) =>
        {
            StateController.ChangeLocalState(new MoveToCollectState(Chacter));
            Debug.Log($"Entered Move To Collect State from {state}");
        };

        StateMachine[CharacterState.MoveToCollect].OnExit = (m, state) => { Debug.Log($"Left Move To Collect State for {state}"); };

        StateMachine[CharacterState.Collect].OnEnter = (m, state) =>
        {
            StateController.ChangeLocalState(new CollectWoodState(Chacter));
            Debug.Log($"Entered Collect State from {state}");
        };
        StateMachine[CharacterState.Collect].OnExit = (m, state) => { Debug.Log($"Left Collect State for {state}"); };
    }

    public void SetState(CharacterState st)
    {
        StateMachine.State = st;
    }

    public override void FixedUpdateNetwork()
    {

    }

}