using System.Collections;
using System.Collections.Generic;
using _Game.Utils;
using _UI.Scripts.Shop.SkinShop;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Scripts.Shop
{
    public class ShopBar : MonoBehaviour
    {
        [SerializeField] private Image bg;
        [SerializeField] private ItemType type;
        
        public ItemType Type => type;
        private UISkinShop shop;
        
        public void SetActive(bool active)
        {
            bg.enabled = !active;
        }
        
        public void SetShop(UISkinShop shop)
        {
            this.shop = shop;
        }

        public void Select()
        {
            shop.SelectShopBar(this);
        }
        
    }
}

