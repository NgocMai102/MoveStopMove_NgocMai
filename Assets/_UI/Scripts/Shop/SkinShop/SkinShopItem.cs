using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.UI.Shop;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
using _UI.Scripts.Shop.SkinShop;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.Shop
{
    public class SkinShopItem : ShopItem
    {
        [SerializeField] private Outline outline;
        [SerializeField] private Image imgLock;
        
        
        
        public void OnInit<T>(ItemType type, ItemData<T> itemData, State state) where T : Enum
        {
            base.OnInit<T>(type, itemData, state);
            SetUIState();
        }

        private void SetSelectUI(bool check)
        {
            this.outline.enabled = check;
        }

        private void SetUIState()
        {
            //imgEquiped.SetActive(CurrentState == State.Unlock);
            imgLock.enabled = CurrentState == State.Lock;
        }
    }
}

