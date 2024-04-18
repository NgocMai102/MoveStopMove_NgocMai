using _Framework;
using _Framework.Pool.Scripts;
using _Game.Utils;
using UnityEngine;

namespace _Game.Scripts.Weapon.Bullet
{
    public abstract class Bullet : GameUnit
    {
        protected Character.Character owner;
        protected Vector3 startPoint;
        protected Vector3 moveDirection;
        protected Vector3 targetPoint;
        protected float moveSpeed;
        protected float maxFlyDistance;

        public void Update()
        {
            Move();
        }
        
        public void OnInit(Character.Character owner, Vector3 target, float size)
        {
            this.owner = owner;
            
            startPoint = TF.position;
            targetPoint = target;
            
            maxFlyDistance = owner.AttackRangeRadius * CharacterUtils.DEFAULT_SPHERE_RADIUS * size;
            moveDirection = new Vector3((targetPoint - TF.position).normalized.x, 0, (targetPoint - TF.position).normalized.z);
            

            TF.forward = new Vector3(moveDirection.x, 0, moveDirection.z);
            TF.localScale = size * Vector3.one;
            
            moveSpeed = BulletSpeed.STRAIGHT * size;
            SetUp();
        }

        
        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagName.CHARACTER))
            {
                Character.Character character = Cache<Character.Character>.GetComponent(other);
                if (character != owner)
                {
                    character.OnHit(owner.CharName);
                    owner.AddScore();
                    OnDespawn();
                }
            }
            else
            {
                OnDespawn();
            }
        }
        
        protected void OnDespawn()
        {
            SimplePool.Despawn(this);
        }

        protected bool CanDespawn()
        {
            return Vector3.Distance(startPoint, TF.position) >= maxFlyDistance;
        }

        public abstract void Move();
        public abstract void SetUp();
    }
}

