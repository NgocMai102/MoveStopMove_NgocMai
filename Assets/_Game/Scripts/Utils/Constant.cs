
using System;

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
        public const float BOOMERANG = 5f;
        public const float STRAIGHT = 9f;
        public const float ROTATION = 1000f;
    }

    public class PlayerProperties
    {
        public const String NAME = "You";
    }
    
    public enum WeaponType
    {
        Hammer = 0,
        Bommerang = 1,
        Knife = 2,
    }

    

    public enum HatType
    {
        None = 0,
        Arrow = 1,
        Cowboy = 2,
        Crown = 3,
        Flower = 4,
        Hair = 5,
        Hat = 6,
        Police = 7,
        Luffy = 8,
        Headphone = 9,
        Horn = 10,
        Rau = 11,
    }

    public enum PantsType 
    {
        Default = 0,
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
        Captain_Shield = 1,
        Batman_Shield = 2,
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
    
    public enum ItemType
    {
        Hat = 0,
        Pants = 1,
        Accessory = 2,
        SetSkin = 3,
        Weapon = 4,
    }

    public enum ButtonState
    {
        Lock = 0,
        Unlock = 1,
        Equipped = 2,
        None = 3,
    }
}



