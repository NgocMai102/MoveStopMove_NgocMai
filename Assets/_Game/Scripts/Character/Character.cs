using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using _Game.UI.Scripts.Gameplay;
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
        
        private Action<Object> onCharacterDie;
        
        private List<Character> enemyInRange;
        private bool isAttackable;

        [SerializeField] private Transform indicatorPoint;
        protected TargetIndicator indicator;
        
        private float attackRangeRadius;
        private float sphereColliderRadius;
        private int score;
        
        [SerializeField] protected bool isDead;
        protected float size = 1;
        

        #region Getter
        
        public bool IsAttackable => isAttackable;
        public bool IsDead => isDead;

        public bool FoundCharacter => enemyInRange.Count > 0;
        public float AttackRangeRadius => attackRangeRadius;
        public float SphereColliderRadius => sphereColliderRadius;
        
        public int Score => score;
        public float Size => size;

        #endregion

        private void Awake()
        {
            RegisterEvents();
        }

        private void Start()
        {
            OnInit();
        }

        public virtual void OnInit()
        {
            attackRangeRadius = 1f;
            isDead = false;
            isAttackable = true;
            score = 0;
            enemyInRange = new List<Character>();
            
            ResetModelRotation();

            currentWeapon.OnInit(this);
            attackRange.OnInit(this);
            
            indicator = SimplePool.Spawn<TargetIndicator>(PoolType.TargetIndicator);
            indicator.SetTarget(indicatorPoint);
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
        
        public Vector3 GetRandomEnemyPos()
        {
            if (enemyInRange.Count == 0)
            {
                return Vector3.zero;
            }
            int randomIndex = Random.Range(0, enemyInRange.Count);
            return enemyInRange[randomIndex].TF.position;
        }
      
        
        public void OnCharacterEnterRange(Character other)
        {
            if (other.isDead)
            {
                return;
            }
            enemyInRange.Add(other);
        }
        
        public void OnCharacterExitRange(Character other)
        {
            enemyInRange.Remove(other);
        }

        #endregion

        #region Score

        public void AddScore(int amount = 1)
        {
            SetScore(score + amount);
        }

        public void SetScore(int score)
        {
            this.score = score > 0 ? score : 0;
            SetSize(1 + this.score * 0.1f);
        }

        #endregion

        public virtual void SetSize(float size)
        {
            size = Mathf.Clamp(size, CharacterUtils.MIN_SIZE, CharacterUtils.MAX_SIZE);
            this.size = size;
            TF.localScale = size * Vector3.one;
        }
        
        public void RotateTo(Vector3 target)
        {
            model.LookAt(target);
        }
        
        public void ResetModelRotation()
        {
            model.localRotation = Quaternion.identity;
        }
        
        
        public void ClearEnemyInRange()
        {
            enemyInRange.Clear();
        }

        public virtual void OnDespawn()
        {
            SimplePool.Despawn(indicator);
        }

        public virtual void OnHit()
        {
            isDead = true;
            this.PostEvent(EventID.OnCharacterDead, this);
            RemoveEvents();
        }
        

        protected virtual void RegisterEvents()
        {
            onCharacterDie = (param) => OnCharacterExitRange((Character) param);
            this.RegisterListener(EventID.OnCharacterDead, onCharacterDie);
        }

        protected virtual void RemoveEvents()
        {
            this.RemoveListener(EventID.OnCharacterDead, onCharacterDie);
        }
        
    }
}

