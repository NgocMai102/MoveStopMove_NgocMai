using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.Skin.Data;
using _Game.Scripts.UI.Shop;
using _Game.Utils;
using UnityEngine;


namespace _Game.Scripts.Character.Player
{
    public class PlayerSkin : CharacterSkin
    {

        public void OnInit()
        {
            base.OnInit();
            ChangeHat((HatType) PlayerData.GetIntData(KeyData.PlayerHat));
            ChangePants((PantsType) PlayerData.GetIntData(KeyData.PlayerPants));
            ChangeAccessory((AccessoryType) PlayerData.GetIntData(KeyData.PlayerAccessory));
           // ChangeWeapon((WeaponType) PlayerData.GetIntData(KeyData.PlayerWeapon));
        }

        private void DespawnPants()
        {
            if (currentPants != null)
            {
                //Destroy(currentPants.gameObject);
            }
        }

        private void TryCloth(ShopItem item) 
        {
            switch (item)
            {
                
            }
        }
        
    }
}

