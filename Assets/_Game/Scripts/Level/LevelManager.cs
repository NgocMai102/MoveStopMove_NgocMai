using System.Collections.Generic;
using _Framework.Pool.Scripts;
using _Framework.Singleton;
using _Framework.StateMachine;
using _Game.Scripts.Character.Enemy;
using _Game.Scripts.Character.Player;
using _Game.Utils;
using _Pattern.StateMachine.EnemyState;
using _UI.Scripts;
using _UI.Scripts.Gameplay;
using _UI.Scripts.Lose;
using _UI.Scripts.Revive;
using _UI.Scripts.Victory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Manager.Level
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private List<Level> levels;
        [SerializeField] public Player player;
        
        private List<Enemy> enemies = new List<Enemy>();
        
        private Level currentLevel;
        private int indexLevel;
        
        private int totalEnemy;
        private int totalCharacter;
        private float maxDistanceMap;
        
        private bool isRevive;

        public int TotalCharacter => totalEnemy + enemies.Count + 1;
        public int IndexLevel => indexLevel;

        public void Start()
        {
            indexLevel = 0;
            OnLoadLevel(indexLevel);
            SetUpLevel();
        }

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
            player.OnInit();
            isRevive = false;

            for (int i = 0; i < currentLevel.TotalEnemyVisible; i++)
            {
                SpawnEnemy(null);
            }

            totalEnemy = currentLevel.TotalEnemyReal - currentLevel.TotalEnemyVisible - 1;

            SetTargetIndicatorAlpha(0);
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

        public void PlayerDeath(Player player)
        {
            UIManager.Instance.CloseAll();
            if (!isRevive)
            {
                isRevive = true;
                UIManager.Instance.OpenUI<UIRevive>();
            }
            else
            {
                OnLose();
            }
        }

        public void EnemyDeath(Enemy enemy)
        {
            enemies.Remove(enemy);

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
            SetUpLevel();
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
            UIManager.Instance.OpenUI<UIGameplay>();
        }

        public void OnLose()
        {
            player.OnLose();
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<UILose>();
        }

        private void Victory()
        {
            player.OnVictory();
            UIManager.Instance.OpenUI<UIVictory>();
            //Next Level
        }

        public void SetTargetIndicatorAlpha(float alpha)
        {
            // List<GameUnit> list = SimplePool.GetAllUnitIsActive(PoolType.TargetIndicator);
            // for (int i = 0; i < list.Count; i++)
            // {
            //     (list[i] as TargetIndicator).SetAlpha(alpha);
            // }
        }
        
    }
}

