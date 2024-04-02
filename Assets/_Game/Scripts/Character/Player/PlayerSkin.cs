using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.Skin.Data;
using _Game.Scripts.UI.Shop;
using _Game.Utils;
using UnityEngine;


namespace _Game.Scripts.Character.Player
{
    public class PlayerSkin : CharacterSkin
    {

        private PlayerData playerData => DataManager.Instance.PlayerData;
        private Action<object> onSelectSkinItem;

        private void OnEnable()
        {
            onSelectSkinItem = (param) => TryCloth((ShopItem) param);
            this.RegisterListener(EventID.OnSelectSkinItem, onSelectSkinItem);
        }

        private void OnDisable()
        {
            this.RemoveListener(EventID.OnSelectSkinItem, onSelectSkinItem);
        }

        public void OnInit()
        {
            base.OnInit();
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
                case ItemType.Set:
                    //TODO: Change model of Character
                    break;
                case ItemType.Weapon:
                    DespawnWeapon();
                    ChangeWeapon((WeaponType) item.ID);
                    break;
            }
        }
        
    }
}

