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
        private const float AttackTime = 1f;
        private const float AttackSpeed = 0.4f;

        private float timer;
        private Vector3 targetPos;
        
        public void OnEnter(Enemy t)
        {
            timer = 0;
            targetPos = t.GetRandomEnemyPos();
            
            t.RotateTo(targetPos);
            t.ChangeAnim(AnimType.ATTACK);
        }

        public void OnExecute(Enemy t)
        {
            timer += Time.deltaTime;
            if(timer >= AttackSpeed && t.IsAttackable)
            {
                t.Attack(targetPos);
            }
            else if(timer >= AttackTime)
            {
                t.ChangeState(new EIdleState());
            }
        }

        public void OnExit(Enemy t)
        {
            
        }
    }
}

