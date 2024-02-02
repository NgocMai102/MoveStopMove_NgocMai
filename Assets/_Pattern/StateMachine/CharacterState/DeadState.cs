using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character;
using UnityEngine;

namespace _Pattern.StateMachine.CharacterState
{
    public class DeadState<T> : IState<T> where T : Character 
    {
        private float despawnTimer = 1.5f;

        private float timer;
        private bool isDespawn;

        public void OnEnter(T t)
        {
            timer = 0;
            isDespawn = false;
        }

        public void OnExecute(T t)
        {
            if (isDespawn)
            {
                return;
            }
            
            timer += Time.deltaTime;
            
            if(timer >= despawnTimer)
            {
                Despawn(t);
            }
        }
        
        protected virtual void Despawn(T t)
        {
            isDespawn = true;
            t.OnDespawn();
        }

        public void OnExit(T t)
        {
            
        }
    }
}


