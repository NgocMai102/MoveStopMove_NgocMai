using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.UI.Shop;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
using _UI.Scripts.Shop.SkinShop;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.Shop
{
    public class SkinShopItem : ShopItem
    {
        [SerializeField] private Outline outline;

        [SerializeField] private UISkinShop shop;
        
        // public void OnEnable()
        // {
        //     base.OnEnable();
        // }

        public void OnDisable()
        {
            SetSelectUI(false);
        }

        public void OnInit<T>(ItemType type, ItemData<T> itemData, State state) where T : Enum
        {
            base.OnInit<T>(type, itemData, state);
            SetUIState();  
            SetState(state);
        }

        public void SetShop(UISkinShop shop)
        {
            this.shop = shop;
        }

        internal void OnSelected()
        {
            shop.SelectItem(this);
        }
        
        public void SetSelectUI(bool check)
        {
            outline.enabled = check;
        }

        private void SetUIState()
        {
            imgLock.SetActive(CurrentState == State.Lock);
        }
    }
}

