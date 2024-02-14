using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Singleton;
using _Game.Scripts.Character.Enemy;
using _Game.Scripts.Character.Player;
using _Game.Utils;
using UnityEngine;

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
                    SpawnCharacter();
                }
            }
            
            // for(int i = 0; i < Constants.MaxBotOnMap; i++)
            // {
            //     if (totalEnemy > 0)
            //     {
            //         totalEnemy--;
            //         SpawnCharacter();
            //     }
            // }
        }

        #region Character

        [SerializeField] private Player player;
        private List<Character.Character> enemies = new List<Character.Character>();

        private void SpawnCharacter()
        {
            
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

        #endregion
        
        
        public Vector3 RandomPoint()
        {
            return Utilities.GetRandomPosOnNavMesh(Vector3.zero, maxDistanceMap);
        }
        
    }
}

