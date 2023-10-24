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

    public List<WoodSource> WoodSources = new();

    public static GameManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Game Manager already exist.");
        }
    }

    public override void Spawned()
    {
        if (Runner.IsServer)
        {
            SetupGame();
        }
    }

    public void CheckEndGame()
    {
        if(Player1Score >= 50)
        {
            EndGame(true);
        }
        else if (Player2Score >= 50) 
        {
            EndGame(false);
        }
    }

    public void EndGame(bool isPlayer1)
    {

    }

    public void SetupGame()
    {
        GameStateController.Instance.ChangeState(GameState.Preparation);
    }

    public static void OnPhotonPlayer1ScoreChanged(Changed<GameManager> changed)
    {
        changed.Behaviour.OnPlayer1ScoreChanged.Invoke();
        changed.Behaviour.CheckEndGame();
    }

    public static void OnPhotonPlayer2ScoreChanged(Changed<GameManager> changed)
    {
        changed.Behaviour.OnPlayer2ScoreChanged.Invoke();
        changed.Behaviour.CheckEndGame();
    }

}
