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

    public TMP_Text SourceText;

    public void Update()
    {
        
    }

    public void Spawned()
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

    public void CollectWood(int collectAmount)
    {
        SourceCount -= (ushort)collectAmount;
        UpdateUIText();

        if(SourceCount <= 0)
        {
            DeleteWoodSource();
        }
    }

    public void DeleteWoodSource()
    {
        if(!Runner.IsServer)
        {
            return;
        }

        WoodPlacementPoint.HaveWoodSource = false;
        Runner.Despawn(Object);
    }

}
