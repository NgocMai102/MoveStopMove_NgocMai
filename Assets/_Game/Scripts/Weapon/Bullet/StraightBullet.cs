using UnityEngine;

namespace _Game.Scripts.Weapon.Bullet
{
    public class StraightBullet : Bullet
    {
        public override void Move()
        {
            TF.position += TF.forward * Time.deltaTime * moveSpeed;
            if (CanDespawn())
            {
                OnDespawn();
            }
        }

        public override void SetUp()
        {
            //Quaternion quaternion = Quaternion.LookRotation(moveDirection);
            //TF.rotation = quaternion;
        }
    }
}

