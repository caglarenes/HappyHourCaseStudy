using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : IGameState
{
    public GameState StateEnum { get; set; } = GameState.End;
    public NetworkRunner NetworkRunner { get; set; }

    public EndState(NetworkRunner networkRunner)
    {
        NetworkRunner = networkRunner;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void UpdateState()
    {
        
    }
}
