using System.Collections;
using System.Collections.Generic;
using _Game.Utils;
using UnityEngine;

namespace _UI.Scripts.Shop.Item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
    public class ItemDataSO : ScriptableObject
    {
        [SerializeField] private List<ItemData<HatType>> hats;
        [SerializeField] private List<ItemData<PantType>> pants;
        [SerializeField] private List<ItemData<WeaponType>> weapons;
        [SerializeField] private List<ItemData<AccessoryType>> accessories;
        [SerializeField] private List<ItemData<SetType>> sets;
        
        public List<ItemData<HatType>> Hats => hats;
        public List<ItemData<PantType>> Pants => pants;
        public List<ItemData<WeaponType>> Weapons => weapons;
        public List<ItemData<AccessoryType>> Accessories => accessories;
        public List<ItemData<SetType>> Sets => sets;
    }
}