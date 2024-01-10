using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using UnityEngine;

namespace _Game.Scripts.Character
{
    public class Character : GameUnit
    {
        //public static event Action<Character> OnCharacterDead;
        [Header("Properties")]
        [SerializeField] private Animator anim;
        [SerializeField] private Transform rightHand;
        
        [Header("Config")]
        [SerializeField] protected float moveSpeed;
        
        private bool isAttackable;
        private bool isDead;

        #region Getter
        
        public bool IsAttackable => isAttackable;
        public bool IsDead => isDead;
        
        #endregion

    }
}

