using System;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _UI.Scripts.Lose
{
    public class UILose : UICanvas
    {
        private int coin;
        [SerializeField] private Text rank;
        [SerializeField] private TextMeshProUGUI nameEnemy;
        [SerializeField] private TextMeshProUGUI cointText;
        [SerializeField] private TextMeshProUGUI pointText;
        [SerializeField] private RectTransform x3Point;
        [SerializeField] private RectTransform continuePoint;

        private PlayerData PlayerData => DataManager.Instance.PlayerData;
        private int point;

        public override void Open()
        {
            base.Open();
            GameManager.Instance.ChangeState(GameState.Lose);
            SetRank(LevelManager.Instance.PlayerRank);
            SetMurder();
            SetPoint();
        }

        public void x3PointButton()
        {
            LevelManager.Instance.Player.TripleCoin();
            LevelManager.Instance.OnHome();
        }

        public void SetPoint()
        {
            cointText.text = PlayerData.GetIntData(KeyData.Coin).ToString();
        }
        

        public void SetMurder()
        {
            nameEnemy.text = LevelManager.Instance.Player.MurderName;
        }
        
        public void SetRank(int rank)
        {
            this.rank.text = "#" + rank.ToString();
        }
    
        public void ContinueButton()
        {
            LevelManager.Instance.OnHome();
        }
    }
}

