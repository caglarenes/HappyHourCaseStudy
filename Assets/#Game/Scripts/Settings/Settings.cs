using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Settings", order = 1)]
public class Settings : ScriptableObject
{
    public static int MaxCharacterCountPerPlayer;

    public int CharacterCountPerPlayer;
    public int EndGameScore;

    public float WoodReachDestination;

    public float CharacterSpawnHeight;

    public int CreateWoodMin;
    public int CreateWoodCount;
    public int MaxWoodCount;
}
