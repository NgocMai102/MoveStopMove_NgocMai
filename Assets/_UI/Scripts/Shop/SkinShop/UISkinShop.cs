using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.UI.Shop;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace _UI.Scripts.Shop.SkinShop
{
    
    public class UISkinShop : UIShop
    {
        [SerializeField] private Transform content;
        [SerializeField] private ShopBar[] shopBars;
        [SerializeField] private SkinShopItem skinShopItemPrefab;
        
        [SerializeField] private ItemDataSO itemDataSO;
        
        private ItemType currentItemType;
        private MiniPool<SkinShopItem> skinItemPool = new MiniPool<SkinShopItem>();
        
        
        protected ShopBar currentBar;

        public void Awake()
        {
            skinItemPool.OnInit(skinShopItemPrefab, 10, content);
            for(int i = 0; i < shopBars.Length; i++)
            {
                shopBars[i].SetShop(this);
            }
        }
        
        public override void Open()
        {
            base.Open();
            currentBar = shopBars[0];
            //SelectShopBar(currentBar);
            //CameraFollow.Instance.ChangeState(CameraFollow.State.Shop);
        }

        public void SelectShopBar(ShopBar shopBar)
        {
            if (shopBar != null)
            {
                currentBar.SetActive(false);
            }
            if (shopBar != currentBar)
            {
                currentItem = null;
            }
            currentBar = shopBar;
            currentBar.SetActive(true);
            currentItemType = currentBar.Type;
            
            ChangeItemType(currentItemType);
        }

        public void ChangeItemType(ItemType type)
        {
            switch (type)
            {
                case(ItemType.Hat):
                    InitShopItem(itemDataSO.Hats, ItemType.Hat);
                    break;
                case(ItemType.Pants):
                    InitShopItem(itemDataSO.Pants, ItemType.Pants);
                    break;
                case(ItemType.Accessory):
                    InitShopItem(itemDataSO.Accessory, ItemType.Accessory);
                    break;
                case(ItemType.Set):
                    InitShopItem(itemDataSO.Sets, ItemType.Set);
                    break;
            }
        }

        public void InitShopItem<T> (List<ItemData<T>> shopItems, ItemType itemType) where T : Enum
        {
            skinItemPool.Collect();
            
            for (int i = 0; i < shopItems.Count; i++)
            {
                SkinShopItem.State state = (SkinShopItem.State) PlayerData.GetItemState(itemType, shopItems[i].Id);
                SkinShopItem item = skinItemPool.Spawn();
                item.OnInit(itemType, shopItems[i], state);
            }
        }
        
    }
    
    
}

