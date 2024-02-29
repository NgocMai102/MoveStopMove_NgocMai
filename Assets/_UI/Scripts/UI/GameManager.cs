﻿using System.Collections;
using System.Collections.Generic;
using _Framework.Singleton;
using _Game.Scripts.Manager.Level;
using _UI.Scripts;
using _UI.Scripts.Gameplay;
using UnityEngine;

namespace _UI.Scripts.UI
{
    public enum GameState
    {
        MainMenu = 0,
        Gameplay = 1,
        GameOver = 3,
        Revive = 4,
        Setting = 5,
        Victory = 6,
    }
    
    public class GameManager : Singleton<GameManager>
    {
        //[SerializeField] UserData userData;
        //[SerializeField] CSVData csv;
        
        private static GameState gameState;
        public static void ChangeState(GameState state)
        {
            gameState = state;
            Instance.OnChangedState(state);
        }
        public static bool IsState(GameState state) => gameState == state;

        private void Awake()
        {
            // Tranh viec nguoi choi cham da diem vao man hinh
            Input.multiTouchEnabled = false;
            // Target frame rate ve 60 fps
            Application.targetFrameRate = 60;
            // Tranh tat man hinh
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            //xu ly tai tho
            int maxScreenHeight = 1280;
            float ratio = 1.0f * Screen.currentResolution.width / Screen.currentResolution.height;
            if (Screen.currentResolution.height > maxScreenHeight)
            {
                Screen.SetResolution(Mathf.RoundToInt(ratio * maxScreenHeight), maxScreenHeight, true);
            }
            
            //csv.OnInit();
            //userData?.OnInitData();
            
            //Init data
            //UserData.Ins.OnInitData();
        }

        private void Start()
        {
            ChangeState(GameState.MainMenu);
        }
        
        private void OnChangedState(GameState state)
        {
            switch (state)
            {
                case GameState.MainMenu:
                    OnMainMenuState();
                    break;
                case GameState.Gameplay:
                    OnGameplayState();
                    break;
                case GameState.GameOver:
                    OnGameOverState();
                    break;
                case GameState.Revive:
                    OnReviveState();
                    break;
                case GameState.Setting:
                    OnSettingState();
                    break;
                case GameState.Victory:
                    OnVictoryState();
                    break;
            }
        }
        
        private void OnMainMenuState()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<MainMenu>();
        }

        private void OnVictoryState()
        {
            Debug.Log("Victory");
            throw new System.NotImplementedException();
        }

        private void OnSettingState()
        {
            Debug.Log("OnSetting");
            throw new System.NotImplementedException();
        }

        private void OnReviveState()
        {
            Debug.Log("Revive");
            throw new System.NotImplementedException();
        }

        private void OnGameOverState()
        {
            Debug.Log("Game Over");
            throw new System.NotImplementedException();
        }

        private void OnGameplayState()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<Gameplay.Gameplay>();
            
            LevelManager.Instance.OnLoadLevel(0);
        }

        
    }
}



