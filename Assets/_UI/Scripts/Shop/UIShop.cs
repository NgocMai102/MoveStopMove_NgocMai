using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using _Game.Scripts.Manager.Level;
using _Game.Scripts.UI.Shop;
using _Game.Utils;
using _UI.Scripts;
using _UI.Scripts.Shop.Item;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

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
        [SerializeField] private ShopType type;
        
        private MiniPool<ShopItem> shopItem;
        
        public override void CloseDirectly()
        {
            base.CloseDirectly();
            UIManager.Instance.OpenUI<UIMainMenu>();
        }

        public void Start()
        {
            
        }
        
        
        private ShopItem currentItem;
        private ShopBar currentBar;

        public void ChangeShopBar(ShopType type)
        {
            switch (type)
            {
                
            }
        }
        
        
        public void SetUpShop(List<ItemDataSO> items)
        {
            shopItem.Collect();
            for(int i = 0; i < items.Count; i++)
            {
                
            }
        }
        
        
        
    }
}

