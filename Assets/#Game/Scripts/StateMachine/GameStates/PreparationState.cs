using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationState : IGameState
{
    public GameState StateEnum { get; set; } = GameState.Preparation;
    public NetworkRunner NetworkRunner { get; set; }

    public Coroutine PreparationCoroutine;

    public PreparationState(NetworkRunner networkRunner)
    {
        NetworkRunner = networkRunner;
    }

    public void OnEnter()
    {
        if(NetworkRunner.IsServer)
        {
            PreparationCoroutine = CoroutineHolder.Instance.StartCoroutine(SetupCharacters());
        }
    }

    public void OnExit()
    {
        if(PreparationCoroutine != null)
        {
            CoroutineHolder.Instance.StopCoroutine(SetupCharacters());
        }
    }

    public void UpdateState()
    {

    }

    public IEnumerator SetupCharacters()
    {
        // Setup Player A minions

        for (int i = 0; i < 3; i++)
        {
            var tempMinion = NetworkRunner.Spawn(PrefabManager.Instance.MinionPrefab);
            var characterScript = tempMinion.GetComponent<Character>();
            characterScript.ChangeCharacterTeam(Team.TeamA);
        }

        // Setup Player B minions

        for (int i = 0; i < 3; i++)
        {
            var tempMinion = NetworkRunner.Spawn(PrefabManager.Instance.MinionPrefab);
            var characterScript = tempMinion.GetComponent<Character>();
            characterScript.ChangeCharacterTeam(Team.TeamB);
        }

        yield return null;

        GameStateController.Instance.ChangeState(GameState.CreateWood);
    }
}
