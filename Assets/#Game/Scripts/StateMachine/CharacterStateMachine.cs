using Fusion;
using UnityEngine;

public class CharacterStateMachine : NetworkBehaviour
{
    private CharacterNetworkStateMachine _sm;

    private void Awake()
    {
        _sm = GetComponent<CharacterNetworkStateMachine>();
    }

    public override void Spawned()
    {
        _sm[CharacterState.Idle].OnEnter = (m, state) => { Debug.Log($"Entered Start State from {state}"); };
        _sm[CharacterState.Idle].OnEnter = (m, state) => { Debug.Log($"Entered Run State from {state}"); };
        _sm[CharacterState.Walk].OnEnter = (m, state) => { Debug.Log($"Entered Dead State from {state}"); };
        _sm[CharacterState.Walk].OnExit = (m, state) => { Debug.Log($"Left Start State for {state}"); };
        _sm[CharacterState.Collect].OnExit = (m, state) => { Debug.Log($"Left Run State for {state}"); };
        _sm[CharacterState.Collect].OnExit = (m, state) => { Debug.Log($"Left Dead State for {state}"); };
    }

    public void OnSetState(int st)
    {
        _sm.State = (CharacterState)st;
    }

    public override void FixedUpdateNetwork()
    {
        OnSetState(2);
    }

}