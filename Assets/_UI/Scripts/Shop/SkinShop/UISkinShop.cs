using System;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.UI.Shop;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
using UnityEngine;

namespace _UI.Scripts.Shop.SkinShop
{
    
    public class UISkinShop : UIShop
    {
        protected ShopBar currentBar;
        
        [SerializeField] private Transform content;
        [SerializeField] private ShopBar[] shopBars;
        [SerializeField] private SkinShopItem skinShopItemPrefab;
        
        
        private ItemType currentItemType;
        private SkinShopItem currentItem;
        [SerializeField] private SkinShopItem equipedItem;
        
        private List<int> equipedTypes = new List<int>();
        private MiniPool<SkinShopItem> skinItemPool = new MiniPool<SkinShopItem>();
        
        private Action<object> onCloseSkinShop;

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
            ReloadData();
            
            currentBar = shopBars[0];
            SelectShopBar(currentBar);
        }
        
        public void OnClickBuyButton()
        {
            //TODO: Check if player has enough coin
            currentItem.SetState(ShopItem.State.Unlock);
            currentItem.SetUIState();
            
            SetButtonState(currentItem);
            
            ReloadData();
        }

        public void OnClickEquipButton()
        { 
            if (currentItem != null) {
                OnResetEquipingItem();
                SetButton((int) ButtonState.Equipped);

                ReloadData();
                currentItem.SetEquippedUI(true);
            }
        }

        internal void SelectShopBar(ShopBar shopBar)
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
                case(ItemType.SetSkin):
                    InitShopItem(itemDataSO.Sets, ItemType.SetSkin);
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
                item.SetShop(this);
                item.SetSelectUI(false);
                
                CheckEquip(item);
            }
        }

        public void CheckEquip(SkinShopItem item)
        {
            if (equipedTypes[(int) item.Type] == Convert.ToInt32(item.ID))
            {
                equipedItem = item;
                SetButtonState(item);
                if (currentItem != null)
                {
                    currentItem = equipedItem;
                }
                
                equipedItem.SetEquippedUI(true);
            }
        }

        public void SelectItem(SkinShopItem item)
        {
            if (currentItem != null)
            {
                currentItem.SetSelectUI(false);
            }
            currentItem = item;
            currentItem.SetSelectUI(true);
            SetButtonState(item);

            if (equipedTypes[(int) item.Type] == Convert.ToInt32(item.ID))
            {
                SetButton((int) ButtonState.Equipped);
            }
            
            this.PostEvent(EventID.OnSelectItem, item);
        }

        public void OnResetEquipingItem()
        {
            if (equipedItem != null)
            {
                equipedItem.SetEquippedUI(false);
            }

            equipedItem = currentItem;
            if (equipedItem != null)
            {
                equipedItem.SetEquippedUI(true);
                PlayerData.OnEquipItem(currentItemType, currentItem.ID);
            }
        }

        #region Data
        public void ReloadData()
        {
            UpdateEquipedData();
            GetEquipedData();
            //TODO: Update coin text
        }
        
        public void GetEquipedData()
        {
            equipedTypes.Clear();
            equipedTypes.Add(PlayerData.GetIntData(KeyData.PlayerHat));
            equipedTypes.Add(PlayerData.GetIntData(KeyData.PlayerPants));
            equipedTypes.Add(PlayerData.GetIntData(KeyData.PlayerAccessory));
            equipedTypes.Add(PlayerData.GetIntData(KeyData.PlayerSetSkin));
        }

        public void UpdateEquipedData()
        {
            if (equipedItem == null)
            {
                return;
            }
            equipedTypes[(int) equipedItem.Type] = Convert.ToInt32(equipedItem.ID);
        }
        #endregion
        
    }
}

