using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
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
           
        
        }

        public void OnExecute(Enemy enemy)
        {
            _timer += Time.deltaTime;
            if (_timer >= idleTime)
            {
                
            }
            
            
        }

        public void OnExit(Enemy enemy)
        {
        
        }
    }

}
