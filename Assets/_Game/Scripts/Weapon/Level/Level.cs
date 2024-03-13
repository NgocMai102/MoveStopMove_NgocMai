using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Manager.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform minPoint,maxPoint;
        [SerializeField] private int totalEnemy;
        [SerializeField] private int totalEnemyReal;
        
        public Transform MinPoint => minPoint;
        public Transform MaxPoint => maxPoint;
        public int TotalEnemy => totalEnemy;    
        public int TotalEnemyReal => totalEnemyReal;
    }
}

