using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using _Framework.Singleton;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
using _Game.Scripts.Character.Player;
using _Game.Utils;
using _Pattern.StateMachine.EnemyState;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Manager.Level
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private List<Level> levels;
        
        private Level currentLevel;
        private int indexLevel;
        
        private int totalEnemy;
        private int totalCharacter;
        private float maxDistanceMap;

        public int TotalCharacter => totalCharacter;

        public void Awake()
        {
            
        }

        public void Start()
        {
            indexLevel = 0;
            OnLoadLevel(indexLevel);
            
        }

        public void OnLoadLevel(int level)
        {
            
            if (currentLevel != null)
            {
                CollectAllCharacter();
                Destroy(currentLevel.gameObject);
            }
            
            currentLevel = Instantiate(levels[level]);
            SetUpLevel();
        }

        private void SetUpLevel()
        {
            totalCharacter = currentLevel.TotalCharacter;
            totalEnemy = totalCharacter - 1;
            maxDistanceMap = currentLevel.MaxDistanceMap;

            for (int i = 0; i < LevelUtils.MAX_CHARACTER; i++)
            {
                if (totalEnemy > 0)
                {
                    totalEnemy--;
                    SpawnEnemy(null);
                }
            }
        }

        #region Character

        [SerializeField] private Player player;
        private List<Enemy> enemies = new List<Enemy>();

        private void SpawnEnemy(IState<Enemy> state)
        {
            Enemy enemy = SimplePool.Spawn<Enemy>(PoolType.Enemy, RandomPoint(), Quaternion.identity);
            enemy.OnInit();
            enemy.ChangeState(state);
            enemies.Add(enemy);
            enemy.SetScore(player.Score > 0 ? Random.Range(player.Score - 7, player.Score + 7) : 1);
            
        }
        
        private void CollectAllCharacter()
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i] as Enemy;
                if (enemy != null)
                {
                    enemy.OnDespawn();
                }
            }
            player.OnDespawn();
        }

        public void EnemyDeath(Enemy enemy)
        {
            enemies.Remove(enemy);
            
            if(GameManager.IsState(GameState.Revive) || GameManager.IsState(GameState.Setting))
            {
                SpawnEnemy(Utilities.Chance(50, 100) ? new EIdleState() : new EPatrolState());
            }
            else
            {
                if (totalEnemy > 0)
                {
                    totalEnemy--;
                    SpawnEnemy(Utilities.Chance(50, 100) ? new EIdleState() : new EPatrolState());
                }

                if (enemies.Count == 0)
                {
                    Victory();
                }
            }
        }

        #endregion

        public void OnPlay()
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i].ChangeState(new EIdleState());
            }
        }

        public void OnRevive()
        {
            player.TF.position = RandomPoint();
            player.OnRevive();
        }
        
        public Vector3 RandomPoint()
        {
            return Utilities.GetRandomPosOnNavMesh(Vector3.zero, maxDistanceMap);
        }
        
        private void Victory()
        {
            
        }
        
    }
}

