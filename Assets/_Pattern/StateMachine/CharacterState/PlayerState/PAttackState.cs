using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Player;
using _Game.Utils;
using UnityEngine;

namespace _Pattern.StateMachine.PlayerState
{
    public class PAttackState : IState<Player>
    {
        private float attackTime = 1f;
        private float attackSpeed = 0.4f;

        private float timer;
        private Vector3 targetPos;
        
        public void OnEnter(Player player)
        {
            timer = 0;
            targetPos = player.GetRandomEnemyPos();
            
            player.RotateTo(targetPos);
            player.ChangeAnim(AnimType.ATTACK);
        }

        public void OnExecute(Player player)
        {
            if (player.IsMoving)
            {
                player.ChangeState(new PRunState());
            }

            timer += Time.deltaTime;
            if (timer >= attackSpeed && player.IsAttackable)
            {
                player.Attack(targetPos);
            }
            else if (timer >= attackTime)
            {
                player.ChangeState(new PIdleState());
            }
        }

        public void OnExit(Player player)
        {
        
        }
    }
}

