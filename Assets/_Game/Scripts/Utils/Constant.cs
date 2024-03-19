using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Utils
{
    public class LevelUtils
    {
        public const int MAX_CHARACTER = 10;
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
        public const float DEFAULT_SPHERE_RADIUS = 5f;
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

    public class BulletSpeed
    {
        public const float STRAIGHT = 9f;
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
        Cowboy = PoolType.HAT_Cowboy,
        Crown = PoolType.HAT_Crown,
        Ear = PoolType.HAT_Ear,
        Flower = PoolType.HAT_Flower,
        Hair = PoolType.HAT_BlondeHair,
        Hat = PoolType.HAT_Cap,
        Police = PoolType.HAT_Police,
        Luffy = PoolType.HAT_Straw,
        Headphone = PoolType.HAT_Headphone,
        Horn = PoolType.HAT_Horn,
        Rau = PoolType.HAT_Rau,
    }

    public enum PantType //PantsType
    {
        None,
        Batman = PoolType.PANT_Batman,
        Chambi = PoolType.PANT_Chambi,
        Comy = PoolType.PANT_Comy,
        Dabao = PoolType.PANT_Dabao,
        Onion = PoolType.PANT_Onion,
        Pokemon = PoolType.PANT_Pokemon,
        Rainbow = PoolType.PANT_Rainbow,
        Skull = PoolType.PANT_Skull,
        Vantim = PoolType.PANT_Vantim,
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



