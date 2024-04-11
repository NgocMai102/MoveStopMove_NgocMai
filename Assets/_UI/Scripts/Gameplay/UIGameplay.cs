using System;
using _Framework.Event.Scripts;
using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.Gameplay
{
    public class UIGameplay : UICanvas
    {
        [SerializeField] private Text aliveText;
        [SerializeField] private GameObject tutorial;
        
        private Action<object> onCharacterDie;

        private int aliveCharacter;


        public override void Open()
        {
            base.Open();
            GameManager.Instance.ChangeState(GameState.Gameplay);

            aliveCharacter = LevelManager.Instance.TotalCharacter;
            SetAliveText(aliveCharacter);

            ShowTutorial();

            LevelManager.Instance.SetTargetIndicatorAlpha(1);
            RegisterEvents();
        }
        
        public override void CloseDirectly()
        {
            base.CloseDirectly();
            RemoveEvents();
            LevelManager.Instance.SetTargetIndicatorAlpha(0);
        }

        public void RegisterEvents()
        {
            onCharacterDie = _ => UpdateTotalCharacter();
            this.RegisterListener(EventID.OnCharacterDead, onCharacterDie);
        }

        public void RemoveEvents()
        {
            this.RemoveListener(EventID.OnCharacterDead, onCharacterDie);
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

