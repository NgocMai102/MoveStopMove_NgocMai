using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
// using Game.Character;
// using Game.Character.Animation;
// using _Game.Scripts.Character.Player;

using UnityEngine;

namespace _Pattern.StateMachine.PlayerState
{
    public class AttackState : IState<Player>
    {
        private float attackTime;
        private float attackSpeed;

        private float timer;
        private Vector3 targetPos;
        
        public void OnEnter(Player player)
        {
            
        }

        public void OnExecute(Player player)
        {
            
        }

        public void OnExit(Player player)
        {
        
        }
    }
}

