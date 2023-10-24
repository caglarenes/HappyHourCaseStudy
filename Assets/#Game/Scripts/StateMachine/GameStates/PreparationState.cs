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
        PhotonManager.Instance.OnPlayersReady.AddListener(PlayersReady);

        if (NetworkRunner.IsServer)
        {
            PreparationCoroutine = CoroutineHolder.Instance.StartCoroutine(SetupCharacters());
        }

        GameStateController.Instance.ChangeUIState(new WaitingUIState());
    }

    public void OnExit()
    {
        if (PreparationCoroutine != null)
        {
            CoroutineHolder.Instance.StopCoroutine(SetupCharacters());
        }

        PhotonManager.Instance.OnPlayersReady.RemoveListener(PlayersReady);

        GameStateController.Instance.ChangeUIState(new SelectCharacterUIState());
    }

    public void UpdateState()
    {

    }

    public void PlayersReady()
    {
        GameStateController.Instance.ChangeState(GameState.CreateWood);
    }

    public IEnumerator SetupCharacters()
    {
        GameManager gameManager = GameManager.Instance;
        MapManager mapManager = MapManager.Instance;
        PrefabManager prefabManager = PrefabManager.Instance;

        // Setup Player A characters

        for (int i = 0; i < gameManager.Settings.CharacterCountPerPlayer; i++)
        {
            var tempMinion = NetworkRunner.Spawn(prefabManager.CharacterPrefab, mapManager.GetRandomPointFromMap(), Quaternion.Euler(mapManager.GetRandomMapFaceRotation()));
            var characterScript = tempMinion.GetComponent<Character>();
            gameManager.player1Characters.Add(characterScript);
            characterScript.ChangeCharacterTeam(Team.TeamA);
        }

        // Setup Player B characters

        for (int i = 0; i < gameManager.Settings.CharacterCountPerPlayer; i++)
        {
            var tempMinion = NetworkRunner.Spawn(prefabManager.CharacterPrefab, mapManager.GetRandomPointFromMap(), Quaternion.Euler(mapManager.GetRandomMapFaceRotation()));
            var characterScript = tempMinion.GetComponent<Character>();
            gameManager.player2Characters.Add(characterScript);
            characterScript.ChangeCharacterTeam(Team.TeamB);
        }

        yield return null;

        GameStateController.Instance.ChangeState(GameState.CreateWood);
    }
}
