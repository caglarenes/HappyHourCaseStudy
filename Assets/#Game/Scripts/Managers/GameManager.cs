using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : NetworkBehaviour
{
    public Settings Settings;

    public List<Character> player1Characters = new(Settings.MaxCharacterCountPerPlayer);
    public List<Character> player2Characters = new(Settings.MaxCharacterCountPerPlayer);


    [Networked(OnChanged = nameof(OnPhotonPlayer1ScoreChanged))]
    public int Player1Score { get; set; }
    [HideInInspector]
    public UnityEvent OnPlayer1ScoreChanged;


    [Networked(OnChanged = nameof(OnPhotonPlayer2ScoreChanged))]
    public int Player2Score { get; set; }
    [HideInInspector]
    public UnityEvent OnPlayer2ScoreChanged;

    public Team PlayerTeam;

    public Team WinnerTeam;
    public UnityEvent OnEndGame;

    public List<WoodSource> WoodSources = new();

    public static GameManager Instance { get; private set; }

    #region Setups

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

        FindObjectOfType<InGameUIManager>().Setup();
    }

    public override void Spawned()
    {
        if (Runner.IsServer)
        {
            SetupGame();
        }

        SetupTeam();
    }


    public void SetupGame()
    {
        GameStateController.Instance.ChangeState(GameState.Preparation);
    }

    private void SetupTeam()
    {
        if (Runner.IsServer)
        {
            PlayerTeam = Team.TeamA;
        }
        else
        {
            PlayerTeam = Team.TeamB;
        }
    }

    #endregion

    #region Game Orders

    public void CheckEndGame()
    {
        if (Player1Score >= Settings.EndGameScore)
        {
            EndGame(Team.TeamA);
        }
        else if (Player2Score >= Settings.EndGameScore)
        {
            EndGame(Team.TeamB);
        }
    }

    public void AddPoint(int point, Team team)
    {
        switch (team)
        {
            case Team.TeamA:
                Player1Score += point;
                break;
            case Team.TeamB:
                Player2Score += point;
                break;
        }

        if (Runner.IsServer)
        {
            CheckEndGame();
        }
    }

    public void EndGame(Team winnerTeam)
    {
        WinnerTeam = winnerTeam;
        OnEndGame.Invoke();

        if (Runner.IsServer)
        {
            RPC_EndGame(winnerTeam);
        }
    }

    public void StopAllCharacters()
    {
        foreach (var characters in player1Characters)
        {
            characters.CharacterStateController.ChangeState(CharacterState.Idle);
        }

        foreach (var characters in player2Characters)
        {
            characters.CharacterStateController.ChangeState(CharacterState.Idle);
        }
    }

    #endregion


    #region Photon Events

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

    [Rpc(sources: RpcSources.StateAuthority, targets: RpcTargets.Proxies)]
    public void RPC_EndGame(Team winnerTeam)
    {
        Debug.Log("RPC_END_GAME");
        EndGame(winnerTeam);
        GameStateController.Instance.ChangeUIState(new EndGameUIState(WinnerTeam));
    }

    #endregion
}
