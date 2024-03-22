using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _UI.Scripts.Shop.Item;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        public enum State {Buy = 0, Bought = 1}
        
        [SerializeField] private GameObject imgLock;

        [SerializeField] private GameObject equiped;
        [SerializeField] private Outline outline;
        [SerializeField] private GameObject EquipedObject;
        
        [SerializeField] private Button selectButton;

        private EventID a;
        

        public int id;
        public State state;

        public Enum type;
        public Button SelectButton => selectButton;

        public void Start()
        {
            //bgIcon.color = colorBG[0];
        }

        public void SetData<T>(int id, ItemData<T> itemData) where T : Enum
        {
            this.id = id;
            //type = itemData.type;
            //icon.sprite = itemData.icon;
            //bgIcon.color = colorBG[(int)state];
        }
        
        public void SetState(State state)
        {
            this.state = state;
            //outline.enabled = true;
            //bgIcon.color = colorBG[(int)state];
        }
        
        
        // public void SetEquiped(bool isEquiped)
        // {
        //     EquipedObject.SetActive(isEquiped);
        //     equiped.SetActive(true);
        // }
        
        
        
    }
}

