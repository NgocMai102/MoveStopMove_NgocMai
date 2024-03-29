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
        [SerializeField] private GameObject[] buttons;
        
        private MiniPool<ShopItem> shopItems;

        public List<Enum> equipedTypes = new List<Enum>();
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
        
        public void InitShopItem<T> (List<ItemData<T>> shopItems, ItemType itemType) where T : Enum
        {

        }
        
        public override void CloseDirectly()
        {
            base.CloseDirectly();
            UIManager.Instance.OpenUI<UIMainMenu>();
        }
        
        public void CloseBtn()
        {
            CloseDirectly();
            UIManager.Instance.OpenUI<UIMainMenu>();
        }
        
    }
}

