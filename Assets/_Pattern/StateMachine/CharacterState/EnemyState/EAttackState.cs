using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
using _Game.Utils;
using UnityEngine;

namespace _Pattern.StateMachine.EnemyState
{
    public class EAttackState : IState<Enemy>
    {
        private const float AttackTime = CharacterUtils.ATTACK_TIME;
        private const float AttackSpeed = CharacterUtils.ATTACK_SPEED;

        private float timer;
        private Vector3 targetPos;
        
        public void OnEnter(Enemy e)
        {
            timer = 0;
            targetPos = e.GetRandomEnemyPos();
            
            e.RotateTo(targetPos);
            e.ChangeAnim(AnimType.ATTACK);
        }

        public void OnExecute(Enemy e)
        {
            timer += Time.deltaTime;
            if(timer >= AttackSpeed && e.IsAttackable)
            {
                e.Attack(targetPos);
            }
            else if(timer >= AttackTime)
            {
                e.ChangeState(new EIdleState());
            }
        }

        public void OnExit(Enemy t)
        {
            
        }
    }
}

