using System;
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
        [SerializeField] private GameObject imgEquiped;
        [SerializeField] private GameObject imgLock;
        
        private UISkinShop shop;
        
        protected void OnEnable()
        {
            SetEquippedUI(false);
        }
        
        public void OnDisable()
        {
            SetSelectUI(false);
        }

        public void OnInit<T>(ItemType type, ItemData<T> itemData, State state) where T : Enum
        {
            base.OnInit<T>(type, itemData, state);
            SetUIState();  
            //SetState(state);
        }

        public void SetShop(UISkinShop shop)
        {
            this.shop = shop;
        }

        internal void OnSelected()
        {
            shop.SelectItem(this);
        }
        
        public void SetEquippedUI(bool isEquip)
        {
            imgEquiped.SetActive(isEquip);
        }

        public void SetSelectUI(bool check)
        {
            outline.enabled = check;
        }

        public void SetUIState()
        {
            imgLock.SetActive(CurrentState == State.Lock);
        }
    }
}

