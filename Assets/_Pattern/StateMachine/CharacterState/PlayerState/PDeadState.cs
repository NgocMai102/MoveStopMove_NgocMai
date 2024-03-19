using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
// using Game.Character.Animation;
using _Game.Scripts.Character.Player;
using _Game.Scripts.Manager.Level;
using _Game.Utils;
using _Pattern.StateMachine.CharacterState;
using _UI.Scripts.UI;
using UnityEngine;


namespace _Pattern.StateMachine.PlayerState
{
    public class PDeadState : IState<Player>
    {
        private float despawnTimer = 1.5f;
        private float timer;
        private bool isDespawn;
        private IState<Player> stateImplementation;

        public void OnEnter(Player t)
        {
            timer = 0;
            isDespawn = false;
            
            t.ChangeAnim(AnimType.DEAD);
            LevelManager.Instance.PlayerDeath(t);
        }

        public void OnExecute(Player t)
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

        protected virtual void Despawn(Player t)
        {
            isDespawn = true;
            t.OnDespawn();
        }

        public void OnExit(Player t)
        {
            
        }
    }
}

