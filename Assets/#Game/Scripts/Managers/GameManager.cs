using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : NetworkBehaviour
{
    [Networked(OnChanged = nameof(OnPhotonPlayer1ScoreChanged))]
    public int Player1Score { get; set; }
    public UnityEvent OnPlayer1ScoreChanged;


    [Networked(OnChanged = nameof(OnPhotonPlayer2ScoreChanged))]
    public int Player2Score { get; set; }
    public UnityEvent OnPlayer2ScoreChanged;

    public override void Spawned()
    {
        if (Runner.IsServer)
        {
            SetupGame();
        }
    }

    public void SetupGame()
    {
        GameStateController.Instance.ChangeState(GameState.Preparation);
    }

    public static void OnPhotonPlayer1ScoreChanged(Changed<GameManager> changed)
    {
        changed.Behaviour.OnPlayer1ScoreChanged.Invoke();
    }

    public static void OnPhotonPlayer2ScoreChanged(Changed<GameManager> changed)
    {
        changed.Behaviour.OnPlayer2ScoreChanged.Invoke();
    }

}
