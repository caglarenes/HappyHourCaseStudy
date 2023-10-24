using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodSource : NetworkBehaviour
{
    [Networked(OnChanged = nameof(OnSourceCountChanged))]
    public ushort SourceCount { get; set; } = 150;

    public WoodPlacementPoint WoodPlacementPoint;

    public Canvas Canvas;
    public TMP_Text SourceText;


    public override void Spawned()
    {
        UpdateUIText();
    }

    public void UpdateUIText()
    {
        SourceText.text = SourceCount.ToString();
    }

    public static void OnSourceCountChanged(Changed<WoodSource> changed)
    {
        changed.Behaviour.UpdateUIText();
    }

    public void CollectWood(int collectAmount, Team playerTeam)
    {
        SourceCount -= (ushort)collectAmount;

        GameManager.Instance.AddPoint(collectAmount, playerTeam);
        UpdateUIText();


        if (SourceCount <= 0)
        {
            DeleteWoodSource();
        }
    }

    public void DeleteWoodSource()
    {
        if (!Runner.IsServer)
        {
            return;
        }

        GameManager.Instance.WoodSources.Remove(this);
        WoodPlacementPoint.HaveWoodSource = false;

        Runner.Despawn(Object);
    }

}
