using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.Skin.Base;
using _Game.Scripts.Skin.Data;
using _Game.Utils;
using UnityEngine;

namespace _Game.Scripts.Character
{
    public class CharacterSkin : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform head;
        [SerializeField] private Transform rightHand;
        [SerializeField] private Transform leftHand;
        //[SerializeField] private Transform pants;
        [SerializeField] private Material pants;
        
        [Header("SkinData")]
        [SerializeField] private SkinDataSO<Hat> headSkin;
        [SerializeField] private SkinDataSO<Accessory> leftHandSkin;
        [SerializeField] private SkinDataSO<Weapon.Weapon> rightHandSkin;
        [SerializeField] private SkinDataSO<Material> pantsSkin;
        
        protected PlayerData PlayerData => DataManager.Instance.PlayerData;

        protected Hat currentHat;
        protected Accessory currentAccessory;
        protected Weapon.Weapon currentWeapon;
        protected Material currentPants;

        public virtual void OnInit()
        {
            TakeOffClothes();
        }

        private void TakeOffClothes()
        {
            DespawnHat();
            DespawnPants(); 
            DespawnAccessory();
            DespawnWeapon();
        }

        protected void ChangeHat(HatType hatType)
        {
            if (hatType != HatType.None)
            {
                currentHat = Instantiate(headSkin.GetSkin((int)hatType), head);
            }
        }
        
        protected void ChangeAccessory(AccessoryType accessoryType)
        {
            if (accessoryType != AccessoryType.None)
            {
                currentAccessory = Instantiate(leftHandSkin.GetSkin((int)accessoryType), leftHand);
            }
        }

        protected void ChangePants(PantsType pantType)
        {
            if (pantType != PantsType.None)
            {
                currentPants = pantsSkin.GetSkin((int)pantType);
                //currentPants = Instantiate(pantsSkin.GetSkin((int)pantType), pants);
            }
        }

        protected void ChangeWeapon(WeaponType weaponType)
        {
           
        }

        protected void DespawnHat()
        {
            if (currentHat)
            {
                Destroy(currentHat.gameObject);
            }
        }
        
        private void DespawnAccessory()
        {
            if (currentAccessory)
            {
                Destroy(currentAccessory.gameObject);
            }
        }
        
        private void DespawnPants()
        {
            if (currentPants)
            {
                
            }
        }
        
        private void DespawnWeapon()
        {
            if (currentWeapon)
            {
                Destroy(currentWeapon.gameObject);
            }
        }
        
    }
}
