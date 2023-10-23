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
        for (int i = 0; i < 3; i++)
        {
            NetworkRunner.Spawn(GameManager.Instance.woodSourcePrefab);
        }

    }

    public void OnExit()
    {

    }

    public void UpdateState()
    {

    }
}
