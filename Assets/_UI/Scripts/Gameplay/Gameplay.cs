using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _Game.Scripts.Manager.Level;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.Gameplay
{
    public class Gameplay : UICanvas
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
        }
        
        private void RegisterEvents()
        {
            onCharacterDead = _ => UpdateTotalCharacter();
            this.RegisterListener(EventID.OnCharacterDead, onCharacterDead);
        }

        private void SetAliveText(int alive)
        {
            aliveText.text = alive.ToString();
        }

        private void ShowTutorial()
        {
            tutorial.SetActive(true);
        }

        private void HideTutorial()
        {
            tutorial.SetActive(false);
        }
        
        private void UpdateTotalCharacter()
        {
            aliveCharacter--;
            SetAliveText(aliveCharacter);
        }
    }
}

