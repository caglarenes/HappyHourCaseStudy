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
    }

}
