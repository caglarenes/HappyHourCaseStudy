using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWoodState : IGameState
{
    public GameState StateEnum { get; set; } = GameState.CreateWood;
    public NetworkRunner NetworkRunner { get; set; }
    public CreateWoodState(NetworkRunner networkRunner)
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
