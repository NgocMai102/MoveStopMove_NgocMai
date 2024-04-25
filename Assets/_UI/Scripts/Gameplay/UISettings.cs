using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Manager.Level;
using _UI.Scripts;
using _UI.Scripts.Gameplay;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;
using LevelManager = _Game.Scripts.Manager.Level.LevelManager;

public class UISettings : UICanvas
{
   
    
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.Setting);
    }

    public void CloseDirectly()
    {
        base.CloseDirectly();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<UIGameplay>();
    }

    public void OnClickRestarButton()
    {
        CloseDirectly();

        LevelManager.Instance.OnRestart();
    }

    public void OnClickHomeButton()
    {
        LevelManager.Instance.OnHome();
    }
}
