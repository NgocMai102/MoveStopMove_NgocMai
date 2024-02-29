using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using UnityEngine;

namespace _UI.Scripts
{
    public class MainMenu : UICanvas
    {
        public void PlayButton()
        {
            GameManager.ChangeState(GameState.Gameplay);
        }
    }
}
