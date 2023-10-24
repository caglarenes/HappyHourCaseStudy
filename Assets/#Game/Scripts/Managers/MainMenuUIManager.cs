using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : ScopedSingleton<MainMenuUIManager>
{
    public List<IView> Views = new();

    public SearchView SearchView;
    public SearchingView SearchingView;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {

    }


    public void CloseAllScreens()
    {
        foreach (var item in Views)
        {
            item.ChangeVisibility(false);
        }
    }

    public void ConnectPhoton()
    {
        MainMenuStateController.Instance.ChangeUIState(new SearchingUIState());
    }

    public void CancelSearch()
    {
        MainMenuStateController.Instance.ChangeUIState(new SearchUIState());
        PhotonManager.Instance.CloseConnection();
    }

}
