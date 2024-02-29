using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;
using _Game.Utils;
using Object = System.Object;

namespace _Game.Scripts.Character
{
    public class Character : GameUnit
    {
        public Transform model;
        //public static event Action<Character> OnCharacterDead;
        [Header("Properties")]
        [SerializeField] private Animator anim;
        [SerializeField] private AttackRange attackRange;
        //[SerializeField] private SphereCollider sphereCollider;
        
        [Header("Config")]
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected Weapon.Weapon currentWeapon;

        private SphereCollider sphereCollider;
        private string currentAnimName;
        private Character otherCharacter;

        private int _score;
        private Action<Object> onCharacterDie;
        
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

        public virtual void OnInit()
        {
            attackRangeRadius = 1f;
            isDead = false;
            isAttackable = true;
            _score = 0;
            enemyInRange = new List<Character>();
            
            ResetModelRotation();
            
            currentWeapon.OnInit(this);
            attackRange.OnInit(this);
            
            RegisterEvents();
            
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
            this.PostEvent(EventID.OnCharacterDead, this);
        }

        public void SetScore(int score)
        {
            if (_score < 0)
            {
                _score = 0;
                return;
            }
            _score = score;
        }

        protected virtual void RegisterEvents()
        {
            onCharacterDie = (param) => OnCharacterExitRange((Character)param);
            this.RegisterListener(EventID.OnCharacterDead, onCharacterDie);
        }

        protected virtual void RemoveEvents()
        {
            this.RemoveListener(EventID.OnCharacterDead, onCharacterDie);
        }
    }
}

