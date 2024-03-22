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
        public const string CHARACTER = "Character";
        public const string WEAPON = "Weapons";
    }

    public class BulletSpeed
    {
        public const float STRAIGHT = 9f;
    }
    
    public enum WeaponType
    {
        Hammer = 0,
        
        W_Candy_1 = 1,
        W_Candy_2 = 2,
        W_Candy_3 = 3,
        W_Boomerang_1 = 4,
        W_Boomerang_2 = 5,
        W_Boomerang_3 = 6,
        Axe_0 = 7,
        Axe_1 = 8,
        Uzi = 9,
        Z = 10,
        Arrow = 11,
    }

    

    public enum HatType
    {
        None = 0,
        Arrow = 1,
        Cowboy = 2,
        Crown = 3,
        Flower = 4,
        Hair = 6,
        Hat = 7,
        Police = 8,
        Luffy = 9,
    }

    public enum PantType 
    {
        None = 0,
        Batman = 1,
        Chambi = 2,
        Comy = 3,
        Dabao = 4,
        Onion = 5,
        Pokemon = 6,
        Rainbow = 7,
        Skull = 8,
        Vantim = 9,
    }
    
    public enum AccessoryType
    {
        None = 0,
        Headphone = 1,
        Horn = 2,
        Rau = 3,
    }

    public enum SetType
    {
        Normal = 0,
        Devil = 1,
        Angel = 2,
        Witch = 3,
        Deadpool = 4,
        Thor = 5,
    }
}



