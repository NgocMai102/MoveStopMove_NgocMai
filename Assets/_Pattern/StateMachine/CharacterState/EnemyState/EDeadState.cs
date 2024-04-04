using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
using _Game.Scripts.Character.Player;
using _Game.Scripts.Manager.Level;
using _Game.Utils;
using _Pattern.StateMachine.CharacterState;
using _Pattern.StateMachine.PlayerState;
// using Game.Character.Animation;
// using _Game.Scripts.Character.Enemy;
using UnityEngine;

namespace _Pattern.StateMachine.EnemyState
{
    public class EDeadState : IState<Enemy>
    {

        private float despawnTimer = 1.8f;
        private float timer;
        private bool isDespawn;

        public void OnEnter(Enemy t)
        {
            timer = 0;
            isDespawn = false;

            LevelManager.Instance.EnemyDeath(t);

            t.ChangeAnim(AnimType.DEAD);
            t.StopMove();
        }

        public void OnExecute(Enemy t)
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
        
        protected virtual void Despawn(Enemy t)
        {
            isDespawn = true;
            t.OnDespawn();
        }

        public void OnExit(Enemy t)
        {
            
        }
    }
}

