using System.Collections;
using System.Collections.Generic;
using _Framework.Singleton;
using _Game.Scripts.Manager;
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
        Finish = 2,
        Revive = 3,
        Setting = 4,
        Victory = 5,
    }
    
    public class GameManager : Singleton<GameManager>
    {
        //[SerializeField] UserData userData;
        //[SerializeField] CSVData csv;
        
        private static GameState gameState;
        public void ChangeState(GameState state)
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
            UIManager.Instance.OpenUI<UIMainMenu>();
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
                case GameState.Finish:
                    OnFinishState();
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
            UIManager.Instance.OpenUI<UIMainMenu>();
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
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<Revive.UIRevive>();

            Debug.Log("Lose");
        }

        private void OnFinishState()
        {
            Debug.Log("Game Over");
            throw new System.NotImplementedException();
        }

        private void OnGameplayState()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<Gameplay.UIGameplay>();
        }

        
    }
}



