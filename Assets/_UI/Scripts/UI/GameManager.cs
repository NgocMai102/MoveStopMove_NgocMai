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
        Lose = 2,
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
            
        }
        public bool IsState(GameState state) => gameState == state;

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
    }
}



