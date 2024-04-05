using _Game.Utils;
using UnityEngine;

namespace _Game.Scripts.Weapon.Bullet
{
    public class RotateBullet: Bullet
    {
        public override void Move()
        {
            TF.position += moveDirection * (moveSpeed * Time.deltaTime);
            
            TF.Rotate(-Vector3.up * BulletSpeed.ROTATION * Time.deltaTime);
            if (CanDespawn())
            {
                OnDespawn();
            }
        }

        public override void SetUp()
        {
           
        }

        
    }
}

