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
using _UI.Scripts;
using _UI.Scripts.Lose;
using _UI.Scripts.Revive;
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
        
        private bool isRevive;

        public int TotalCharacter => totalEnemy + enemies.Count + 1;
        public int IndexLevel => indexLevel;

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
            player.OnInit();
            isRevive = false;
            //Indicator
            
            for (int i = 0; i < currentLevel.TotalEnemyReal; i++)
            {
                SpawnEnemy(null);
            }
            totalEnemy = currentLevel.TotalEnemy - currentLevel.TotalEnemyReal - 1;
        }

        private void OnReset()
        {
            player.OnDespawn();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].OnDespawn();
            }
            enemies.Clear();
            SimplePool.CollectAll();
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
                Enemy enemy = enemies[i];
                if (enemy != null)
                {
                    enemy.OnDespawn();
                }
            }
            player.OnDespawn();
        }

        public void CharacterDead(Character.Character character)
        {
            if (character is Player)
            {
                UIManager.Instance.CloseAll();
                //TODO: Anim revive of Score Txt in GamePlay State
                if (!isRevive)
                {
                    isRevive = true;
                    UIManager.Instance.OpenUI<UIRevive>();
                }
                else
                {
                    OnFail();
                }
            } else if (character is Enemy)
            {
                enemies.Remove(character as Enemy);
            
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
        }

        #endregion
        
        public Vector3 RandomPoint()
        {
            return Utilities.GetRandomPosOnDistance(currentLevel.MinPoint, currentLevel.MaxPoint);
        }

        public void NextLevel()
        {
            indexLevel++;
        }

        public void OnHome()
        {
            UIManager.Instance.CloseAll();
            OnReset();
            OnLoadLevel(indexLevel);
            UIManager.Instance.OpenUI<UIMainMenu>();
        }

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

        public void OnFail()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<UILose>();
        }

        private void Victory()
        {
            UIManager.Instance.OpenUI<UIVictory>();
        }
        
    }
}

