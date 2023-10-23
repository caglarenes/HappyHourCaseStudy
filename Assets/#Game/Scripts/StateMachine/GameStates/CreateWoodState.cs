using Fusion;
using System;
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
            WoodPlacementPoint _woodPlacementPoint = null;
            if (!MapManager.Instance.TryGetRandomEmptyWoodPlacementPoint(ref _woodPlacementPoint))
            {
                break;
            }

            _woodPlacementPoint.HaveWoodSource = true;

            var createdWoodSource = NetworkRunner.Spawn(PrefabManager.Instance.WoodSourcePrefab, _woodPlacementPoint.transform.position, _woodPlacementPoint.transform.rotation);
            var woodSource = createdWoodSource.gameObject.GetComponent<WoodSource>();
            woodSource.WoodPlacementPoint = _woodPlacementPoint;
        }

    }

    public void OnExit()
    {

    }

    public void UpdateState()
    {

    }
}
