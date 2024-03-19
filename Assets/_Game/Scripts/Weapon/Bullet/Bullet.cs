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
        private Character.Character owner;

        private Vector3 startPoint;
        private Vector3 moveDirection;
        private float maxFlyDistance;
        
        protected float moveSpeed;

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
                    owner.AddScore();
                    OnDespawn();
                }
            }
            else
            {
                OnDespawn();
            }
        }

        public void OnInit(Character.Character owner, Vector3 targetPoint, float size)
        {
            this.owner = owner;
            startPoint = TF.position;
            maxFlyDistance = owner.AttackRangeRadius * CharacterUtils.DEFAULT_SPHERE_RADIUS * size;
            //moveDirection = (targetPoint - TF.position).normalized;
            //moveDirection.y = 0;

            TF.forward = new Vector3((targetPoint - TF.position).normalized.x, 0, (targetPoint - TF.position).normalized.z);

            //TF.rotation = Quaternion.LookRotation(moveDirection);
            TF.localScale = size * Vector3.one;
            moveSpeed = BulletSpeed.STRAIGHT * size;
        }

        private void OnDespawn()
        {
            SimplePool.Despawn(this);
        }

        protected virtual void Move()
        {
            TF.position += TF.forward * (moveSpeed * Time.deltaTime);
        }
        
        protected virtual bool CanDespawn()
        {
            return Vector3.Distance(startPoint, TF.position) >= maxFlyDistance;
        }
    }
}

