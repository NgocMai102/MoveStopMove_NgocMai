using _Game.Camera;
using _Game.Scripts.Manager.Level;
using _UI.Scripts.Gameplay;
using _UI.Scripts.Shop.SkinShop;
using _UI.Scripts.Shop.WeaponShop;
using _UI.Scripts.UI;

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
           CameraFollow.Instance.OnReset();
        }

        public void ShopButton()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<UISkinShop>();
            
            CameraFollow.Instance.ChangeState(CameraFollow.State.Shop);
        }

        public void WeaponButton()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<UIWeaponShop>();
        }
    }
}
