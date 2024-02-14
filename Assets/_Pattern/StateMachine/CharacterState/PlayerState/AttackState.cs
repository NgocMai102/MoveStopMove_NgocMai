using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Player;

using UnityEngine;

namespace _Pattern.StateMachine.PlayerState
{
    public class AttackState : IState<Player>
    {
        private float attackTime = 1f;
        private float attackSpeed = 0.4f;

        private float timer;
        private Vector3 targetPos;
        
        public void OnEnter(Player player)
        {
            timer = 0;
            targetPos = player.GetRandomEnemyPos();
        }

        public void OnExecute(Player player)
        {
            if (player.IsMoving)
            {
                player.ChangeState(new RunState());
            }

            timer += Time.deltaTime;
            if (timer >= attackSpeed && player.IsAttackable)
            {
                player.Attack(targetPos);
            }
            else if (timer >= attackTime)
            {
                player.ChangeState(new IdleState());
            }
        }

        public void OnExit(Player player)
        {
        
        }
    }
}

