using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;
using _Game.Utils;

namespace _Game.Scripts.Character
{
    public class Character : GameUnit
    {
        public Transform model;
        //public static event Action<Character> OnCharacterDead;
        [Header("Properties")]
        [SerializeField] private Animator anim;
        [SerializeField] private Transform rightHand;
        [SerializeField] private AttackRange attackRange;
        //[SerializeField] private SphereCollider sphereCollider;
        
        [Header("Config")]
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected Weapon.Weapon currentWeapon;

        private SphereCollider sphereCollider;
        private string currentAnimName;
        private Character otherCharacter;
        
        private List<Character> enemyInRange;
        private bool isAttackable;
        private bool isDead;
        private float attackRangeRadius;
        private float sphereColliderRadius;

        #region Getter
        
        public bool IsAttackable => isAttackable;
        public bool IsDead => isDead;
        public bool FoundCharacter => enemyInRange.Count > 0;
        public float AttackRangeRadius => attackRangeRadius;
        public float SphereColliderRadius => sphereColliderRadius;

        #endregion

        private void Start()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            attackRangeRadius = 1f;
            isDead = false;
            isAttackable = true;
            enemyInRange = new List<Character>();
            
            ResetModelRotation();
            
            currentWeapon.OnInit(this);
            attackRange.OnInit(this);
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

        #region Attack
        
        public void Attack(Vector3 target)
        {
            currentWeapon.SpawnBullet(target);
            StartCoroutine(ResetAttack());
        }
        
        private IEnumerator ResetAttack()
        {
            isAttackable = false;
            currentWeapon.gameObject.SetActive(false);

            yield return new WaitForSeconds(1.5f);

            isAttackable = true;
            currentWeapon.gameObject.SetActive(true);
        }

        #endregion
        
        public void RotateTo(Vector3 target)
        {
            model.LookAt(target);
        }
        
        public void ResetModelRotation()
        {
            model.localRotation = Quaternion.identity;
        }
        
        public Vector3 GetRandomEnemyPos()
        {
            int randomIndex = Random.Range(0, enemyInRange.Count);
            return enemyInRange[randomIndex].TF.position;
        }
      
        
        public void OnCharacterEnterRange(Character other)
        {
            if (isDead)
            {
                return;
            }
            enemyInRange.Add(other);
        }
        
        public void OnCharacterExitRange(Character other)
        {
            enemyInRange.Remove(other);
        }

        public virtual void OnDespawn()
        {
            
        }

        public virtual void OnHit()
        {
            isDead = true;
        }
    }
}

