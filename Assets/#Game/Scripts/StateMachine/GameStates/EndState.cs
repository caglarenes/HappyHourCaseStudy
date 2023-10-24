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
        if (NetworkRunner.IsServer)
        {
            GameManager.Instance.StopAllCharacters();
            GameStateController.Instance.ChangeUIState(new EndGameUIState(GameManager.Instance.WinnerTeam));
        }
    }

    public void OnExit()
    {

    }

    public void UpdateState()
    {

    }
}
