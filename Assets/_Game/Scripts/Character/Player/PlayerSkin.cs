using System;
using _Framework.Event.Scripts;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.UI.Shop;
using _Game.Utils;
using UnityEngine;

namespace _Game.Scripts.Character.Player
{
    public class PlayerSkin : CharacterSkin
    {
        
        private PlayerData PlayerData => DataManager.Instance.PlayerData;
        private Action<object> onSelectItem;
        private Action<object> onCloseShop;
        private Action<object> OnSelectShopBar;

        private void OnEnable()
        {
            onSelectItem = (param) => TryCloth((ShopItem) param);
            this.RegisterListener(EventID.OnSelectItem, onSelectItem);
            
            onCloseShop = _ => WearClothes();
            this.RegisterListener(EventID.OnCloseShop, onCloseShop);

            OnSelectShopBar = _ => WearClothes();
            this.RegisterListener(EventID.OnSelectShopBar, OnSelectShopBar);

        }

        public override void WearClothes()
        {
            base.WearClothes();
            ChangeHat((HatType) PlayerData.GetIntData(KeyData.PlayerHat));
            ChangePants((PantsType) PlayerData.GetIntData(KeyData.PlayerPants));
            ChangeAccessory((AccessoryType) PlayerData.GetIntData(KeyData.PlayerAccessory));
            ChangeWeapon((WeaponType) PlayerData.GetIntData(KeyData.PlayerWeapon));
        }

        private void TryCloth(ShopItem item) 
        {
            switch (item.Type)
            {
                case ItemType.Hat:
                    DespawnHat();
                    ChangeHat((HatType) item.ID);
                    break;
                case ItemType.Pants:
                    DespawnPants();
                    ChangePants((PantsType) item.ID);
                    break;
                case ItemType.Accessory:
                    DespawnAccessory();
                    ChangeAccessory((AccessoryType) item.ID);
                    break;
                case ItemType.SetSkin:
                    TakeOffClothes();
                    Player player = (Player) owner;
                    player.SetSkin((SetType) item.ID);
                    break;
                case ItemType.Weapon:
                    DespawnWeapon();
                    ChangeWeapon((WeaponType) item.ID);
                    break;
            }
        }

        private void ChangeWeapon(WeaponType weaponType)
        {
            base.ChangeWeapon(weaponType);
            Debug.Log("ChangeWeapons");
        }
    }
}

