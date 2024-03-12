using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _Game.Scripts.Manager;
using _Game.Scripts.Manager.Level;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.Gameplay
{
    public class UIGameplay : UICanvas
    {
        [SerializeField] private Text aliveText;
        [SerializeField] private GameObject tutorial;
        
        private Action<object> onCharacterDead;

        private int aliveCharacter;
        

        public override void Open()
        {
            base.Open();

            aliveCharacter = LevelManager.Instance.TotalCharacter;
            SetAliveText(aliveCharacter);

            ShowTutorial();
            Invoke("HideTutorial", 3.0f);
            EventInput.InputManager.FindJoyStick();
            
            RegisterEvents();
        }

        public void RegisterEvents()
        {
            onCharacterDead = _ => UpdateTotalCharacter();
            this.RegisterListener(EventID.OnCharacterDead, onCharacterDead);
        }

        public void SetAliveText(int alive)
        {
            aliveText.text = alive.ToString();
        }

        public void ShowTutorial()
        {
            tutorial.SetActive(true);
        }

        public void HideTutorial()
        {
            tutorial.SetActive(false);
        }
        
        public void UpdateTotalCharacter()
        {
            aliveCharacter--;
            SetAliveText(aliveCharacter);
        }
    }
}

