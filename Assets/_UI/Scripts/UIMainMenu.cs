using _Game.Camera;
using _Game.Scripts.Manager.Level;
using _UI.Scripts.Gameplay;
using _UI.Scripts.UI;
using UnityEngine;

namespace _UI.Scripts
{
    public class UIMainMenu : UICanvas
    {
        public override void Open()
        {
            base.Open();
            CameraFollow.Instance.ChangeState(CameraFollow.State.MainMenu);
        }
        
        public void PlayButton()
        {
            UIManager.Instance.CloseAll();

            GameManager.Instance.ChangeState(GameState.Gameplay);
            CameraFollow.Instance.ChangeState(CameraFollow.State.Gameplay);
            
            LevelManager.Instance.OnPlay();
        }
    }
}
