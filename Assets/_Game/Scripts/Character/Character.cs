using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Event.Scripts;
using _Framework.Pool.Scripts;
using _Game.UI.Scripts.Gameplay;
using UnityEngine;
using Random = UnityEngine.Random;
using _Game.Utils;
using _UI.Scripts.Gameplay;
using _UI.Scripts.UI;
using Object = System.Object;

namespace _Game.Scripts.Character
{
    public class Character : GameUnit
    {
        public Transform model;
        [Header("Properties")]
        [SerializeField] private Animator anim;
        [SerializeField] private AttackRange attackRange;
        [SerializeField] protected CharacterSkin characterSkin;

        [Header("Config")]
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected Weapon.Weapon currentWeapon;
        [SerializeField] protected NameDataSO nameData;
        [SerializeField] private Transform indicatorPoint;

        private SphereCollider sphereCollider;
        private string currentAnimName;
        private Action<Object> onCharacterDie;
        
        private List<Character> enemyInRange = new List<Character>();
        private bool isAttackable;
        private float attackRangeRadius;
        
        protected TargetIndicator indicator;
        protected String name;
        protected String murder;
        protected int score;
        
        protected bool isDead;
        protected float size;
        
        #region Getter
        public Weapon.Weapon CurrentWeapon => currentWeapon;
        public Vector3 ThrowPoint => characterSkin.RightHand.position;
        
        public bool IsAttackable => isAttackable;
        public bool IsDead => isDead;

        public bool FoundCharacter => enemyInRange.Count > 0;
        public float AttackRangeRadius => attackRangeRadius;

        public String Name => name;
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
            InitTargetIndicator();
            InitProperties();
            ResetModelRotation();

            attackRange.OnInit(this);
            characterSkin.OnInit(this);
            score = 0;
        }
        
        public void InitTargetIndicator()
        {
            if (!indicator)
            {
                indicator = SimplePool.Spawn<TargetIndicator>(PoolType.TargetIndicator);
//                Debug.Log(SimplePool.GetAllUnitIsActive(PoolType.Enemy));
//                Debug.Log("indicator");
            }
            indicator.SetTarget(indicatorPoint);
        }
        
        public void InitProperties()
        {
            attackRangeRadius = 1f;
            size = 1;
            SetSize(size);

            isDead = false;
            isAttackable = true;
            enemyInRange.Clear();
        }
        
        public void SetWeapon(Weapon.Weapon weapon)
        {
            currentWeapon = weapon;
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
            currentWeapon.SpawnBullet(target, this);
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
            if (!other.isDead && other != null && GameManager.Instance.IsState(GameState.Gameplay))
            {
                enemyInRange.Add(other);
            }
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
            indicator.SetScore(score);
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
            Vector3 tmpPos = target - model.position;
            tmpPos.y = 0;
            TF.forward = tmpPos.normalized;
            
        }
        
        public void ResetModelRotation()
        {
            TF.localRotation = Quaternion.Euler(0, 180, 0);
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
        }

        public virtual void StopMove()
        {
            
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

