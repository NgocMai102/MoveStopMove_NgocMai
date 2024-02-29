using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using _Framework.Singleton;
using _Game.Scripts.Character.Enemy;
using _Game.Scripts.Character.Player;
using _Game.Utils;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game.Scripts.Manager.Level
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private List<Level> levels;
        
        private Level currentLevel;
        private int totalEnemy;
        private int totalCharacter;
        private float maxDistanceMap;

        public int TotalCharacter => totalCharacter;

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
                    SpawnEnemy();
                }
            }
        }

        #region Character

        [SerializeField] private Player player;
        private List<Character.Character> enemies = new List<Character.Character>();

        private void SpawnEnemy()
        {
            Character.Character enemy = SimplePool.Spawn<Character.Character>(PoolType.Enemy, RandomPoint(), Quaternion.identity);
            enemy.OnInit();
            
            //TODO: Set socre for enemy
            
            enemies.Add(enemy);
            
            
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
                SpawnEnemy();
            }
            else
            {
                if (totalEnemy > 0)
                {
                    totalEnemy--;
                    SpawnEnemy();
                }

                if (enemies.Count == 0)
                {
                    Victory();
                }
            }
        }

        #endregion
        
        
        public Vector3 RandomPoint()
        {
            return Utilities.GetRandomPosOnNavMesh(Vector3.zero, maxDistanceMap);
        }
        
        private void Victory()
        {
            
        }
        
    }
}

