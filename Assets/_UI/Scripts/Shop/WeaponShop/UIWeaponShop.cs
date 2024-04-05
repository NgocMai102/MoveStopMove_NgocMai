using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using _Game.Scripts.Skin.Data;
using _Game.Scripts.UI.Shop.WeaponShop;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
using UnityEngine;

namespace _UI.Scripts.Shop.WeaponShop
{
    public class UIWeaponShop : UIShop
    {
        [SerializeField] private WeaponShopItem weaponShopItemPrefab;
        
        
        private int currentWeaponId;

        public override void Open()
        {
            base.Open();
            currentWeaponId = 0;
            InitWeaponItem(currentWeaponId);
        }

        public void InitWeaponItem(int id)
        {
            WeaponShopItem.State state = (WeaponShopItem.State) PlayerData.GetItemState(ItemType.Weapon, itemDataSO.Weapons[id].Id);
            weaponShopItemPrefab.OnInit(ItemType.Weapon, itemDataSO.Weapons[id], state);
            
            OnSelectItem();
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

        public void OnSelectItem()
        {
            PlayerData.OnEquipItem(ItemType.Weapon, itemDataSO.Weapons[currentWeaponId].Id);
            this.PostEvent(EventID.OnSelectItem, itemDataSO.Weapons[currentWeaponId].Id);
        }
        
    }
}
