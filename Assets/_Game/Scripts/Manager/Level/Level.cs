using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Manager.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private float maxDistanceMap;
        [SerializeField] private int totalCharacter;
        [SerializeField] private int totalCharacterFake;
        
        public float MaxDistanceMap => maxDistanceMap;
        public int TotalCharacter => totalCharacter;
        public int TotalCharacterFake => totalCharacterFake;
    }
}

