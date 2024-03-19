using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
using _Game.Scripts.Manager.Level;
using _Game.Utils;
// using _Game.Scripts.Character.Enemy;
// using Game.Character.Animation;
using UnityEngine;


namespace _Pattern.StateMachine.EnemyState
{
    public class EPatrolState : IState<Enemy>
    {
        private int chanceAttack = Random.Range(0, 100);
        private Vector3 nextDestination;
        
        private bool attackIfEnemyInRange;
        public void OnEnter(Enemy enemy)
        {
            nextDestination = LevelManager.Instance.RandomPoint();
            attackIfEnemyInRange = Utilities.Chance(chanceAttack);
            
            enemy.ChangeAnim(AnimType.RUN);
            enemy.MoveTo(nextDestination);
            enemy.ResetModelRotation();
        }

        public void OnExecute(Enemy enemy)
        {
            if (enemy.IsDestination)
            {
                enemy.ChangeState(new EIdleState());
            }
            if (enemy.FoundCharacter && attackIfEnemyInRange)
            {
                enemy.ChangeState(new EIdleState());
            }
            
            if (enemy.IsDead )
            {
                enemy.ChangeState(new EDeadState());
            }
        
        }

        public void OnExit(Enemy t)
        {
        
        }
    }
}

