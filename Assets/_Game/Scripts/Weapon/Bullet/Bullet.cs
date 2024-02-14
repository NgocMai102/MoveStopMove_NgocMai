using System;
using System.Collections;
using System.Collections.Generic;
using _Framework;
using _Framework.Pool.Scripts;
using _Game.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Weapon.Bullet
{
    public class Bullet : GameUnit
    {
        [SerializeField] private float moveSpeed;

        private Character.Character owner;

        private Vector3 startPoint;
        private Vector3 moveDirection;

        private float maxFlyDistance;

        private void Update()
        {
            Move();

            if (CanDespawn())
            {
                OnDespawn();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagName.CHARACTER))
            {
                Character.Character character = Cache<Character.Character>.GetComponent(other);
                if (character != owner)
                {
                    character.OnHit();
                    OnDespawn();
                }
            }
            else
            {
                OnDespawn();
            }
        }

        public void OnInit(Character.Character owner, Vector3 targetPoint)
        {
            this.owner = owner;
            startPoint = TF.position;
            maxFlyDistance = owner.AttackRangeRadius;

            moveDirection = (targetPoint - startPoint).normalized;
            moveDirection.y = 0;
            
            TF.rotation = Quaternion.LookRotation(moveDirection);
        }

        private void OnDespawn()
        {
            SimplePool.Despawn(this);
        }

        protected virtual void Move()
        {
            TF.position += moveDirection * (moveSpeed * Time.deltaTime);
        }
        
        protected virtual bool CanDespawn()
        {
            return Vector3.Distance(startPoint, TF.position) >= maxFlyDistance;
        }
    }
}

