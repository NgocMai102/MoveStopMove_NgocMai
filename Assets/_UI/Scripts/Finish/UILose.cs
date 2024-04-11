using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using TMPro;
using UnityEngine;


namespace _UI.Scripts.Lose
{
    public class UILose : UICanvas
    {
        private int coin;
        // [SerializeField] private TextMeshProUGUI rank;
        // [SerializeField] private TextMeshProUGUI nameEnemy;
        [SerializeField] private TextMeshProUGUI cointText;
        [SerializeField] private RectTransform x3Point;
        [SerializeField] private RectTransform continuePoint;
    
        public override void Open()
        {
            base.Open();
            GameManager.Instance.ChangeState(GameState.Lose);
        }

        public void x3PointButton()
        {
            LevelManager.Instance.OnHome();
        
        }
    
        public void ContinueButton()
        {
            LevelManager.Instance.OnHome();
        }
    }
}

