using System;
using _Framework.Event.Scripts;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.UI.Shop;
using _Game.Scripts.UI.Shop.WeaponShop;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using UnityEngine;

namespace _UI.Scripts.Shop.WeaponShop
{
    public class UIWeaponShop : UIShop
    {
        [SerializeField] private WeaponShopItem weaponShopItem;

        [SerializeField] private int currentWeaponId;
        
        private WeaponShopItem currentItem;
        private int equipedWeaponId;

        public override void Open()
        {
            base.Open();
            currentWeaponId = 0;
            InitWeaponItem(currentWeaponId);
        }

        public void InitWeaponItem(int id)
        {
            WeaponShopItem.State state = (WeaponShopItem.State) PlayerData.GetItemState(ItemType.Weapon, itemDataSO.Weapons[id].Id);
            weaponShopItem.OnInit(ItemType.Weapon, itemDataSO.Weapons[id], state);
            currentItem = weaponShopItem;
            SetButtonState(weaponShopItem);
            
            OnSelectWeapon();
        }

        public void SelectWeapon(WeaponType type)
        {
            
        }

        public void OnNextButton()
        {
            currentWeaponId++;
            if (currentWeaponId >= itemDataSO.Weapons.Count)
            {
                currentWeaponId = 0;
            }
            InitWeaponItem(currentWeaponId);
        }
        
        public void OnBackButton()
        {
            currentWeaponId--;
            if (currentWeaponId < 0)
            {
                currentWeaponId = itemDataSO.Weapons.Count - 1;
            }
            InitWeaponItem(currentWeaponId);
        }
        
        public void OnClickBuyButton()
        {
            //TODO: Check if player has enough coin
            currentItem.SetState(ShopItem.State.Unlock);

            SetButtonState(weaponShopItem);
            ReloadData();
        }

        public void OnClickEquipButton()
        { 
            if (currentItem != null) {
                PlayerData.OnEquipItem(weaponShopItem.Type, weaponShopItem.ID);
                SetButton((int) ButtonState.Equipped);

                ReloadData();
            }
        }

        public void ReloadData()
        {
            UpdateEquipedItem();
        }
        
        public void OnResetEquipedWeapon()
        {
            
        }

        public void UpdateEquipedItem()
        {
            if (equipedWeaponId == null)
            {
                return;
            }
            equipedWeaponId = PlayerData.GetIntData(KeyData.PlayerWeapon);
        }

        public void OnSelectWeapon()
        {
            //PlayerData.OnEquipItem(ItemType.Weapon, itemDataSO.Weapons[currentWeaponId].Id);
            this.PostEvent(EventID.OnSelectItem, weaponShopItem);
        }
        
    }
}
