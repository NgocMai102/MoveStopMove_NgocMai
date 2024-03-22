using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        public enum State {Buy = 0, Bought = 1}

        [SerializeField] private Image icon;
        [SerializeField] private Image bgIcon;
        //[SerializeField] private Color[] colorBG;
        
        [SerializeField] private GameObject EquipedObject;

        private EventID a;
        

        public int id;
        public State state;

        public Enum type;

        public void Start()
        {
            //bgIcon.color = colorBG[0];
        }

        public void SetData<T>(int id, ShopItemData<T> itemData) where T : Enum
        {
            this.id = id;
            type = itemData.type;
            icon.sprite = itemData.icon;
            //bgIcon.color = colorBG[(int)state];
        }
        
        public void SetState(State state)
        {
            this.state = state;
            //bgIcon.color = colorBG[(int)state];
        }
        
        public void SetEquiped(bool isEquiped)
        {
            EquipedObject.SetActive(isEquiped);
        }
    }
}

