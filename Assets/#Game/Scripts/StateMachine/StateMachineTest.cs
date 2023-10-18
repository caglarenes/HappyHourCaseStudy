using Fusion;
using UnityEngine;

public class StateMachineTest : NetworkBehaviour
{
    private GameStateMachine _sm;

    private void Awake()
    {
        _sm = GetComponent<GameStateMachine>();

    }

    public override void Spawned()
    {
        _sm[GameState.Start].OnEnter = (m, state) => { Debug.Log($"Entered Start State from {state}"); };
        _sm[GameState.Run].OnEnter = (m, state) => { Debug.Log($"Entered Run State from {state}"); };
        _sm[GameState.Dead].OnEnter = (m, state) => { Debug.Log($"Entered Dead State from {state}"); };
        _sm[GameState.Start].OnExit = (m, state) => { Debug.Log($"Left Start State for {state}"); };
        _sm[GameState.Run].OnExit = (m, state) => { Debug.Log($"Left Run State for {state}"); };
        _sm[GameState.Dead].OnExit = (m, state) => { Debug.Log($"Left Dead State for {state}"); };
    }

    public void OnSetState(int st)
    {
        _sm.State = (GameState)st;
    }

    public override void FixedUpdateNetwork()
    {
        Debug.Log("ASD");
        OnSetState(2);
    }

}