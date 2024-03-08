using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.Revive
{
    public class UIRevive : UICanvas
    {
        [SerializeField] private TextMeshProUGUI countdownText;
        private float countdown;
        
        public override void Setup()
        {
            base.Setup();
            
            countdown = 10;
        }

        public void Update()
        {
            if (this.countdown > 0)
            {
                this.countdown -= Time.deltaTime;
                this.countdownText.SetText(this.countdown.ToString("F0"));
                if (this.countdown <= 0)
                {
                    this.CloseButton();
                }
            }
        }

        public void ReviveButton()
        {
            GameManager.Instance.ChangeState(GameState.Gameplay);
            CloseButton();
            //LevelManager.Instance.OnRevive();
        }

        public void CloseButton()
        {
            Close(0);
            
        }
        
        
        
    }
}


