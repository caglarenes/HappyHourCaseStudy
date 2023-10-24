using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : ScopedSingleton<InGameUIManager>
{
    public List<IView> Views = new();

    public WaitingView WaitingView;
    public SelectCharacterView SelectCharacterView;
    public CharacterSelectedView CharacterSelectedView;
    public EndGameView EndGameView;

    public InfoView InfoView;


    public void Setup()
    {
        InfoView.Setup();
        GameManager.Instance.OnEndGame.AddListener(ShowEndGameScreen);
    }

    public void ShowEndGameScreen()
    {
        GameStateController.Instance.ChangeState(GameState.End);
    }

    public void ReturnMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void CloseAllScreens()
    {
        foreach (var item in Views)
        {
            item.ChangeVisibility(false);
        }
    }

    public void Deselect()
    {
        GameStateController.Instance.ChangeUIState(new SelectCharacterUIState());
    }
}
