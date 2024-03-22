using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Manager.Level;
using _Game.Scripts.UI.Shop;
using _UI.Scripts;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
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
        
        public override void CloseDirectly()
        {
            base.CloseDirectly();
            UIManager.Instance.OpenUI<UIMainMenu>();
        }
        
        
        private ShopItem currentItem;
        private ShopBar currentBar;

        private void AddListener()
        {
            
        }

        
    }
}

