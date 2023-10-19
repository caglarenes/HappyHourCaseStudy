using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ScopedSingleton<GameManager>
{
    public GameObject minionPrefab;

    public void SetupGame()
    {
        GameStateController.Instance.ChangeState(GameState.Preparation);
    }
}
