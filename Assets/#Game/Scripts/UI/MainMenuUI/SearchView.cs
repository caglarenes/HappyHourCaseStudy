using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchView : IView
{
    public int Level = 1;

    public TMP_Text LevelText;

    public void LevelUpButton()
    {
        Level++;
        SetLevel();
    }

    public void LevelDownButton()
    {
        Level--;
        SetLevel();
    }

    private void SetLevel()
    {
        Level = Mathf.Clamp(Level, 1, 5);
        LevelText.text = Level.ToString();

        PhotonManager.Instance.PlayerLevel = Level;
    }

    public void SearchGame()
    {
        MainMenuUIManager.Instance.ConnectPhoton();
    }
}
