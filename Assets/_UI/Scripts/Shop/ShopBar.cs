using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.UI.Scripts.Shop
{
    public class ShopBar : UICanvas
    {
        [SerializeField] GameObject bg;
        [SerializeField] UIShop.ShopType type;
        
        public UIShop.ShopType Type => type;
        private UIShop shop;
        
        public void SetShop(UIShop shop)
        {
            this.shop = shop;
        }
        
        
    }
}


