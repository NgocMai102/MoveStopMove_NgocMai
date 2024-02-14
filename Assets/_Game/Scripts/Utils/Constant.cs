using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Utils
{
    public class LevelUtils
    {
        public const int MAX_CHARACTER = 15;
    }
    public class AnimType
    {
        public const string IDLE = "idle";
        public const string WIN = "win";
        public const string RUN = "run";
        public const string ULTI = "ulti";
        public const string DANCE = "dance";
        public const string ATTACK = "attack";
        public const string DEAD = "dead";
    }
    
    public class CharacterUtils
    {
        public const float ATTACK_TIME = 1f;
        public const float ATTACK_SPEED = 0.4f;
        public const float DEFAULT_SPHERE_RADIUS = 4.9f;
    }
    
    public class TagName
    {
        public const string PLAYER = "Player";
        public const string ENEMY = "Enemy";
        public const string CHARACTER = "Character";
        public const string WEAPON = "Weapons";
    }
}



