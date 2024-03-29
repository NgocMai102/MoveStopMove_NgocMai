using System;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using _Game.Scripts.UI.Shop;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
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
        private SkinShopItem currentItem;
        [SerializeField] private SkinShopItem equipedItem;
        private MiniPool<SkinShopItem> skinItemPool = new MiniPool<SkinShopItem>();
        
        
        protected ShopBar currentBar;

        public void Awake()
        {
            skinItemPool.OnInit(skinShopItemPrefab, 0, content);
            for(int i = 0; i < shopBars.Length; i++)
            {
                shopBars[i].SetShop(this);
            }
        }
        
        public override void Open()
        {
            base.Open();
            currentBar = shopBars[0];
            
            ReloadData();
            //CameraFollow.Instance.ChangeState(CameraFollow.State.Shop);
        }

        public void ReloadData()
        {
            SelectShopBar(currentBar);
            GetEquipedData();
            //TODO: Update coin text
        }

        public void OnClickBuyButton()
        {
            //TODO: Check if player has enough coin
            currentItem.SetState(ShopItem.State.Unlock);
            currentItem.SetLock(false);
            
            SetButtonState(currentItem);
            Debug.Log(currentItem);
            Debug.Log(currentItem.CurrentState);
            
            ReloadData();
            
            currentItem.SetSelect();
            
        }

        public void OnClickEquipButton()
        { 
            if (currentItem != null) {
                ReloadData();
                OnResetEquipingItem();
            
                SetButton((int) ButtonState.Equipped);
            }
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
            base.InitShopItem(shopItems, itemType);
            
            skinItemPool.Collect();
            
            for (int i = 0; i < shopItems.Count; i++)
            {
                SkinShopItem.State state = (SkinShopItem.State) PlayerData.GetItemState(itemType, shopItems[i].Id);
                SkinShopItem item = skinItemPool.Spawn();
                item.OnInit(itemType, shopItems[i], state);
                
                item.SetShop(this);
                CheckEquip(item);
            }
            
        }

        public void CheckEquip(SkinShopItem item)
        {
            if (equipedTypes.Contains(item.Type))
            {
                equipedItem = item;
                SetButtonState(item);
                if (currentItem != null)
                {
                    currentItem = equipedItem;
                }
                
                SelectItem(currentItem);
                equipedItem.SetEquipped(true);

                currentItem.SetSelect();
            }
        }

        public void SelectItem(SkinShopItem item)
        {
            // an/hien outline
            if (currentItem != null)
            {
                currentItem.SetSelectUI(false);
            }
            currentItem = item;
            currentItem.SetSelectUI(true);
            SetButtonState(item);
            
            if(equipedTypes.Contains(item.Type))
            {
                SetButton((int) ButtonState.Equipped);
            }
        }

        public void OnResetEquipingItem()
        {
            if (equipedItem)
            {
                equipedItem.SetEquipped(false);
            }

            equipedItem = currentItem;
            if (equipedItem != null)
            {
                equipedItem.SetEquipped(true);
            }
//            equipedTypes[(int) currentItemType] = equipedItem.Type;
            //Debug.Log((int) currentItemType);
        }

        public void GetEquipedData()
        {
            equipedTypes.Clear();
            // equipedTypes.Add(ItemType.Hat);
            // equipedTypes.Add(ItemType.Pants);
            // equipedTypes.Add(ItemType.Accessory);
            // equipedTypes.Add(ItemType.Set);
        }

    }
    
    
}

