using UnityEngine;

namespace _Game.Scripts.Manager.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform minPoint,maxPoint;
        //so luong hien tren man hinh
        [SerializeField] private int totalEnemyVisible;
        //so luong that su
        [SerializeField] private int totalEnemyReal;
        
        public Transform MinPoint => minPoint;
        public Transform MaxPoint => maxPoint;
        public int TotalEnemyVisible => totalEnemyVisible;    
        public int TotalEnemyReal => totalEnemyReal;
    }
}

