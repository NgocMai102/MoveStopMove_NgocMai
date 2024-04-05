
using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;

namespace _UI.Scripts.Victory
{
    public class UIVictory : UICanvas
    {
        public override void Open()
        {
            base.Open();
            GameManager.Instance.ChangeState(GameState.Victory);
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

