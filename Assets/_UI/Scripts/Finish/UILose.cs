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
        // [SerializeField] private TextMeshProUGUI nameEnemy;
        [SerializeField] private TextMeshProUGUI cointText;
        [SerializeField] private RectTransform x3Point;
        [SerializeField] private RectTransform continuePoint;
    
        public override void Open()
        {
            base.Open();
            GameManager.Instance.ChangeState(GameState.Lose);
            SetRank(LevelManager.Instance.PlayerRank);
        }

        public void x3PointButton()
        {
            LevelManager.Instance.OnHome();
        
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

