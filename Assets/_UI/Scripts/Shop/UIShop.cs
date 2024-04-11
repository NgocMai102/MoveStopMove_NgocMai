using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.UI.Shop;
using _UI.Scripts;
using _UI.Scripts.Shop.Item;
using UnityEngine;

namespace _Game.UI.Scripts.Shop
{
    public class UIShop : UICanvas
    {
        [SerializeField] protected ItemDataSO itemDataSO;
        [SerializeField] private GameObject[] buttons;

        private MiniPool<ShopItem> shopItems;
        protected PlayerData PlayerData => DataManager.Instance.PlayerData;
        

        protected void SetButtonState(ShopItem item)
        {
            int index = (int) item.CurrentState;
            SetButton(index);
        }

        protected void SetButton(int index)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
            
            if (index < buttons.Length)
            {
                buttons[index].SetActive(true);
            }
        }
        
        public override void CloseDirectly()
        {
            base.CloseDirectly();
            UIManager.Instance.OpenUI<UIMainMenu>();
            this.PostEvent(EventID.OnCloseShop);
        }

    }
}

