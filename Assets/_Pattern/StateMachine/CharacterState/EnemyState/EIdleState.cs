using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
using _Game.Utils;
// using Game.Character.Animation;
using UnityEngine;
// using _Game.Scripts.Character.Enemy;
using Random = UnityEngine.Random;

namespace _Pattern.StateMachine.EnemyState
{
    public class EIdleState : IState<Enemy>
    {
        private float idleTime = Random.Range(2f, 5f);
        private float _timer = 0;
        public void OnEnter(Enemy enemy)
        {
            _timer = 0;
           
            enemy.StopMove();
            enemy.ChangeAnim(AnimType.IDLE);
        
        }

        public void OnExecute(Enemy enemy)
        {
            _timer += Time.deltaTime;
            if (_timer >= idleTime)
            {
                enemy.ChangeState(new EPatrolState());
            }
            
            if (enemy.FoundCharacter && enemy.IsAttackable)
            {
                enemy.ChangeState(new EAttackState());
            }
            
        }

        public void OnExit(Enemy enemy)
        {
        
        }
    }

}
