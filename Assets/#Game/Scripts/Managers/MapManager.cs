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

        return pointRes.constClampedPosition;
    }

    public Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(-20,20), 1.02f, Random.Range(-20,20));
    }

}
