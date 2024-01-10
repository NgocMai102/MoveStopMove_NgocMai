using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using UnityEngine;

namespace _Game.Scripts.Character
{
    public class Character : GameUnit
    {
        public Transform model;
        //public static event Action<Character> OnCharacterDead;
        [Header("Properties")]
        [SerializeField] private Animator anim;
        [SerializeField] private Transform rightHand;
        
        [Header("Config")]
        [SerializeField] protected float moveSpeed;
        
        
        private string currentAnimName;
        private float attackRangeRadius;
        private Character otherCharacter;
        
        private List<Character> enemyInRange;
        private bool isAttackable;
        private bool isDead;

        #region Getter
        
        public bool IsAttackable => isAttackable;
        public bool IsDead => isDead;
        public bool FoundCharacter => enemyInRange.Count > 0;
        public float AttackRangeRadius => attackRangeRadius;
        
        #endregion
        
        void Awake()
        {
            
        }

        private void Start()
        {
            OnInit();
        }

        protected void OnInit()
        {
            isDead = false;
            isAttackable = true;
            enemyInRange = new List<Character>();
        }
        
        #region Animation
        public void ChangeAnim(string animName)
        {
            if (currentAnimName != animName)
            {
                anim.ResetTrigger(animName);
                currentAnimName = animName;
                if (currentAnimName != null)
                    anim.ResetTrigger(currentAnimName);
                anim.SetTrigger(currentAnimName);
            }
        }
        #endregion
        
        public void RotateTo(Vector3 target)
        {
            model.LookAt(target);
        }
    }
}

