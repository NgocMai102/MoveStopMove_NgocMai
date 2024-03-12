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
            
            GameManager.Instance.ChangeState(GameState.MainMenu);
            CameraFollow.Instance.ChangeState(CameraFollow.State.MainMenu);
            
            //TODO: Add Coin Text
        }
        
        public void PlayButton()
        {
           UIManager.Instance.CloseAll();
           UIManager.Instance.OpenUI<UIGameplay>();
           
           LevelManager.Instance.OnPlay();
           
           CameraFollow.Instance.ChangeState(CameraFollow.State.Gameplay);
        }

        public void ShopButton()
        {
            
        }

        public void WeaponButton()
        {
            
        }
    }
}
