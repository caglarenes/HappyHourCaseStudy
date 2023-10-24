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
}
