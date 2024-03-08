using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Utils
{
    public class LevelUtils
    {
        public const int MAX_CHARACTER = 50;
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
        public const float ATTACK_SPEED = 0.25f;
        public const float DEFAULT_SPHERE_RADIUS = 4.9f;
        public const float MIN_SIZE = 1f;
        public const float MAX_SIZE = 4f;
    }
    
    public class TagName
    {
        public const string PLAYER = "Player";
        public const string ENEMY = "Enemy";
        public const string CHARACTER = "Character";
        public const string WEAPON = "Weapons";
    }
    
    public enum WeaponType
    {
        Hammer = PoolType.W_Hammer,
        
        W_Candy_1 = PoolType.W_Candy_1,
        W_Candy_2 = PoolType.W_Candy_2,
        W_Candy_3 = PoolType.W_Candy_3,
        W_Boomerang_1 = PoolType.W_Boomerang_1,
        W_Boomerang_2 = PoolType.W_Boomerang_2,
        W_Boomerang_3 = PoolType.W_Boomerang_3,
    }

    public enum HairType
    {
        None,
        Arrow = PoolType.HAT_Arrow,
        Crown = PoolType.HAT_Crown,
        Ear = PoolType.HAT_Ear,
        Cap = PoolType.HAT_Cap,
        Hair = PoolType.HAT_BlondeHair,
        Police = PoolType.HAT_Police,
        Flower = PoolType.HAT_Flower,
        Horn = PoolType.HAT_Horn,
        Rau = PoolType.HAT_Rau,
    }

    public enum PantType //PantsType
    {
        None,
        Batman,
    }
    
    public enum AccessoryType
    {
        None,
    }

    public enum SkinType
    {
        None,
        Normal = PoolType.SKIN_Normal,
        
    }
}



