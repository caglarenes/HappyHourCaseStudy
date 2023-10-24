using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Settings", order = 1)]
public class Settings : ScriptableObject
{
    public static int MaxCharacterCountPerPlayer;

    public int CharacterCountPerPlayer;
    public int EndGameScore;

    public float WoodReachDestination;
}
