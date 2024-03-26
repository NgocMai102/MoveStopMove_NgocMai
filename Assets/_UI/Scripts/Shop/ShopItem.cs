using System;
using _Game.Scripts.Manager.Data;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
using _UI.Scripts.Shop.SkinShop;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        public enum State {Lock = ButtonState.Buy, Unlock = ButtonState.Equip}

        [SerializeField] protected Image imgIcon;
        [SerializeField] private GameObject imgEquiped;

        public int id;
        public State CurrentState { get; private set; }
        public Enum Type {get; private set;}
        public Enum ID { get; private set; }
        public int Cost { get; private set; }
        
        protected PlayerData PlayerData => DataManager.Instance.PlayerData;
        
        public void OnInit<T>(ItemType type, ItemData<T> itemData, State state) where T : Enum
        {
            Type = type;
            ID = itemData.Id;
            Cost = itemData.Cost;
            imgIcon.sprite = itemData.Sprite;
            CurrentState = state;
        }
        
        public void OnEquip()
        {
            SetState(State.Unlock);
            
        }
        
        public void SetState(State state)
        {
            CurrentState = state;
            PlayerData.SetItemState((ItemType)Type, ID, (int) state);
        }

    }
}

