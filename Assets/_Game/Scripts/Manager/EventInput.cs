using System.Collections;
using System.Collections.Generic;
using _Framework.Singleton;
using UnityEngine;


namespace _Game.Scripts.Manager
{
    public class EventInput : Singleton<EventInput>
    {
        [SerializeField] private Joystick joystick;
        
        public float HorizontalAxis => joystick.Horizontal;
        public float VerticalAxis => joystick.Vertical;
        
        public void FindJoyStick()
        {
            if(joystick == null)
            {
                joystick = FindObjectOfType<Joystick>();
            }
        }
        
        public bool HasInput()
        {
            if(joystick == null)
            {
                return false;
            }
            
            return Vector2.Distance(joystick.Direction, Vector2.zero) > 0.1f;
        }
    }
}

