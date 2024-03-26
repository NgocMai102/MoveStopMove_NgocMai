using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.Manager.Level;
using _Game.Scripts.UI.Shop;
using _Game.Utils;
using _UI.Scripts;
using _UI.Scripts.Shop.Item;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace _Game.UI.Scripts.Shop
{
    public class UIShop : UICanvas
    {
        //[SerializeField] private ShopType type;
        [SerializeField] private GameObject[] buttons;


        private List<Enum> equipedItems;
        private MiniPool<ShopItem> shopItems;
        
        protected ShopItem currentItem;
        protected PlayerData PlayerData => DataManager.Instance.PlayerData;
        
        public override void CloseDirectly()
        {
            base.CloseDirectly();
            UIManager.Instance.OpenUI<UIMainMenu>();
        }

        private void SetItem(ShopItem item)
        {
            currentItem = item;
            SetButtonState(item);
        }

        private void SetButtonState(ShopItem item)
        {
            int index = (int) item.CurrentState;
            SetButton(index);
            // switch (index)
            // {
            //     case ButtonState.Buy:
            //         SetButton(ButtonState.Buy);
            //         break;
            //     
            //     
            // }
        }

        private void SetButton(int index)
        {
            //int index = (int)state;
            for (int i = 1; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
            if (index < buttons.Length)
            {
                buttons[index].SetActive(true);
            }
        }


        public void CloseBtn()
        {
            CloseDirectly();
            UIManager.Instance.OpenUI<UIMainMenu>();
        }
    }
}

