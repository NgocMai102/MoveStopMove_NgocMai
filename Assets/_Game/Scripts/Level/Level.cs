using UnityEngine;

namespace _Game.Scripts.Manager.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform minPoint,maxPoint;
        //so luong hien tren man hinh
        [SerializeField] private int totalCharacterVisible;
        //so luong that su
        [SerializeField] private int totalCharacterReal;
        
        public Transform MinPoint => minPoint;
        public Transform MaxPoint => maxPoint;
        public int TotalCharacterReal => totalCharacterReal;    
        public int TotalCharacterVisible => totalCharacterVisible;
    }
}

