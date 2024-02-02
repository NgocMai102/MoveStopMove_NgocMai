using System.Collections;
using System.Collections.Generic;
using _Framework.Singleton;
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
                Destroy(currentLevel.gameObject);
            }
        }
    }
}

