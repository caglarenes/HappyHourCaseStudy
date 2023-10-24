using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectState : IGameState
{
    public GameState StateEnum { get; set; } = GameState.Collect;
    public NetworkRunner NetworkRunner { get; set; }

    public CollectState(NetworkRunner networkRunner)
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
        if (NetworkRunner.IsServer)
        {
            if (GameManager.Instance.WoodSources.Count <= 2)
            {
                GameStateController.Instance.ChangeState(GameState.CreateWood);
            }
        }
    }
}
