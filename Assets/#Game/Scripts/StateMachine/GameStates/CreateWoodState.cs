using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWoodState : IGameState
{

    public GameState StateEnum { get; set; } = GameState.CreateWood;
    public NetworkRunner NetworkRunner { get; set; }

    private Coroutine CreateWoodCoroutine;
    public CreateWoodState(NetworkRunner networkRunner)
    {
        NetworkRunner = networkRunner;
    }

    public void OnEnter()
    {
        if (NetworkRunner.IsServer)
        {
            CoroutineHolder.Instance.StartCoroutine(CreateWoods());
        }
    }

    public void OnExit()
    {
        if (CreateWoodCoroutine != null)
        {
            CoroutineHolder.Instance.StopCoroutine(CreateWoodCoroutine);
        }
    }

    public void UpdateState()
    {

    }

    public IEnumerator CreateWoods(int woodCount = 3)
    {
        for (int i = 0; i < woodCount; i++)
        {
            WoodPlacementPoint _woodPlacementPoint = null;
            if (!MapManager.Instance.TryGetRandomEmptyWoodPlacementPoint(ref _woodPlacementPoint))
            {
                break;
            }

            _woodPlacementPoint.HaveWoodSource = true;

            var createdWoodSource = NetworkRunner.Spawn(PrefabManager.Instance.WoodSourcePrefab, _woodPlacementPoint.transform.position, _woodPlacementPoint.transform.rotation);
            var woodSource = createdWoodSource.gameObject.GetComponent<WoodSource>();
            woodSource.WoodPlacementPoint = _woodPlacementPoint;
            GameManager.Instance.WoodSources.Add(woodSource);
            yield return new WaitForSeconds(0.2f);
        }

        GameStateController.Instance.ChangeState(GameState.Collect);
    }
}
