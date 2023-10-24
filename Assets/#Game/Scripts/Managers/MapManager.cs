using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MapManager : ScopedSingleton<MapManager>
{
    public AstarPath Pathfinder;

    public List<WoodPlacementPoint> WoodPlacementPoints = new();

    public bool TryGetRandomEmptyWoodPlacementPoint(ref WoodPlacementPoint woodPlacementPoint)
    {
        var emptyPoints = WoodPlacementPoints.FindAll(x => x.HaveWoodSource == false);

        if (emptyPoints == null || emptyPoints.Count == 0)
        {
            woodPlacementPoint = null;
            return false;
        }

        var randomNumber = Random.Range(0, emptyPoints.Count);
        woodPlacementPoint = emptyPoints[randomNumber];

        return true;
    }

    public Vector3 GetRandomPointFromMap()
    {
        var pointRes = ((RecastGraph)Pathfinder.graphs[0]).GetNearest(GetRandomPoint());

        return new Vector3(pointRes.constClampedPosition.x, GameManager.Instance.Settings.CharacterSpawnHeight, pointRes.constClampedPosition.z);
    }

    public Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(-30, 30), 1.02f, Random.Range(-30, 30));
    }

    public Vector3 GetRandomMapFaceRotation()
    {
        var randomNumber = Random.Range(0, 2);

        switch (randomNumber)
        {
            case 0:
                return new Vector3(0, 180, 0);
            case 1:
                return new Vector3(0, 270, 0);
            default:
                return new Vector3(0, 180, 0);
        }
    }

}
