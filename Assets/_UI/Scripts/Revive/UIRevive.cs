using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using TMPro;
using UnityEngine;

namespace _UI.Scripts.Revive
{
    public class UIRevive : UICanvas
    {
        [SerializeField] private TextMeshProUGUI countdownText;
        private float countdown;
        
        public override void Setup()
        {
            base.Setup();
            GameManager.Instance.ChangeState(GameState.Revive);
            countdown = 10;
        }

        public void Update()
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
                countdownText.SetText(this.countdown.ToString("F0"));
                if (countdown <= 0)
                {
                    CloseButton();
                }
            }
        }

        public void ReviveButton()
        {
            GameManager.Instance.ChangeState(GameState.Gameplay);
            Close(0);
            LevelManager.Instance.OnRevive();
        }

        public void CloseButton()
        {
            Close(0);
            LevelManager.Instance.OnLose();
        }
    }
}


