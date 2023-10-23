using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : ScopedSingleton<MapManager>
{
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
}
