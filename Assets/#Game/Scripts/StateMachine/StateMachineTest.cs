using Fusion;
using UnityEngine;

public class StateMachineTest : NetworkBehaviour
{
    private GameNetworkStateMachine _sm;

    private void Awake()
    {
        _sm = GetComponent<GameNetworkStateMachine>();
    }

    public override void Spawned()
    {
        _sm[GameState.Preparation].OnEnter = (m, state) => 
        {
            Debug.Log($"Entered Preparation State from {state}");
            GameStateController.Instance.ChangeLocalState(new PreparationState(Runner)); 
        };

        _sm[GameState.Preparation].OnExit = (m, state) => { Debug.Log($"Left Preparation State from {state}"); };

        _sm[GameState.Collect].OnEnter = (m, state) => 
        { 
            Debug.Log($"Entered Collect State from {state}");
            GameStateController.Instance.ChangeLocalState(new CollectState(Runner));
        };

        _sm[GameState.Collect].OnExit = (m, state) => { Debug.Log($"Left Collect State for {state}"); };

        _sm[GameState.CreateWood].OnEnter = (m, state) => 
        { 
            Debug.Log($"Entered Collect State from {state}");
            GameStateController.Instance.ChangeLocalState(new CreateWoodState(Runner));
        };

        _sm[GameState.CreateWood].OnExit = (m, state) => { Debug.Log($"Left Collect State for {state}"); };

        _sm[GameState.End].OnEnter = (m, state) => 
        {
            Debug.Log($"Entered End State from {state}");
            GameStateController.Instance.ChangeLocalState(new EndState(Runner));
        };

        _sm[GameState.End].OnExit = (m, state) => { Debug.Log($"Left End State for {state}"); };
    }

    public void SetState(GameState st)
    {
        _sm.State = st;
    }

    public override void FixedUpdateNetwork()
    {
        
    }

}