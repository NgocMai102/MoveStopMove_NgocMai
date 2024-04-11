using System;
using _Game.Scripts.Skin.Base;
using _Game.Scripts.Skin.Data;
using _Game.Utils;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace _Game.Scripts.Character
{
    public abstract class CharacterSkin : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform head;
        [SerializeField] private Transform rightHand;
        [SerializeField] private Transform leftHand;
        [SerializeField] private Renderer pants;

        [Header("SkinData")]
        [SerializeField] private SkinDataSO<Hat> headSkin;
        [SerializeField] private SkinDataSO<Accessory> leftHandSkin;
        [SerializeField] private SkinDataSO<Weapon.Weapon> rightHandSkin;
        [SerializeField] private SkinDataSO<Material> pantsSkin;


        protected Hat currentHat;
        protected Accessory currentAccessory;
        protected Weapon.Weapon currentWeapon;
        protected Renderer currentPants;

        protected Character owner;

        public Transform RightHand => rightHand;

        public virtual void OnInit(Character character)
        {
            owner = character;
        }

        public virtual void WearClothes()
        {
            TakeOffClothes();
        }

        protected void TakeOffClothes()
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
        
        protected void ChangeWeapon(WeaponType weaponType)
        {
            currentWeapon = Instantiate(rightHandSkin.GetSkin((int)weaponType), rightHand);
            owner.SetWeapon(currentWeapon);
        }

        protected void ChangePants(PantsType pantType)
        {
            if (pantType != PantsType.None)
            {
                pants.material = pantsSkin.GetSkin((int)pantType); 
            }
        }
        
        protected void DespawnHat()
        {
            if (currentHat)
            {
                Destroy(currentHat.gameObject);
            }
        }
        
        protected void DespawnAccessory()
        {
            if (currentAccessory)
            {
                Destroy(currentAccessory.gameObject);
            }
        }

        protected void DespawnWeapon()
        {
            if (currentWeapon)
            {
                Destroy(currentWeapon.gameObject);
            }
        }
        
        protected void DespawnPants()
        {
            if (currentPants)
            {
                pants.materials = Array.Empty<Material>();
            }
        }
        
    }
}
