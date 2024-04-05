using System;
using _Game.Scripts.Manager.Data;
using _Game.Utils;
using _UI.Scripts.Shop.Item;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        public enum State
        {
            Lock = ButtonState.Lock,
            Unlock = ButtonState.Unlock
        }
        //public enum State {Lock = 0, Unlock = 1}

        [SerializeField] protected Image imgIcon;


        public int id;
        public State CurrentState { get; private set; }
        public ItemType Type { get; private set; }
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
        
        public void SetState(State state)
        {
            CurrentState = state;
            PlayerData.SetItemState(Type, ID, (int)state);
        }
    }
}

