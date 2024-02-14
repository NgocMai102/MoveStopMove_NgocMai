using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
using _Game.Scripts.Manager.Level;
using _Pattern.StateMachine.CharacterState;
using _Pattern.StateMachine.PlayerState;
// using Game.Character.Animation;
// using _Game.Scripts.Character.Enemy;
using UnityEngine;

namespace _Pattern.StateMachine.EnemyState
{
    public class EDeadState : DeadState<Enemy>
    {
        public void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
            enemy.StopMove();
        }

        protected override void Despawn(Enemy enemy)
        {
            base.Despawn(enemy);
            //LevelManager.Instance.EnemyDeath(enemy);
        }
    }
}

