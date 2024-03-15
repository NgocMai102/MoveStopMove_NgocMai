using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.UI.Shop;
using UnityEngine;

namespace _Game.UI.Scripts.Shop
{
    public class UIShop : UICanvas
    {
        public enum ShopType
        {
            Hat,
            Paint,
            Accesory,
            Skin
        }
        
        [SerializeField] private ShopBar[] shopBars;
        [SerializeField] private ShopItem prefab;
        
        //private MiniPool<ShopItem> miniPool = new MiniPool<ShopItem>();
        
        private ShopItem currentItem;
        private ShopBar currentBar;
        
        
    }
}

