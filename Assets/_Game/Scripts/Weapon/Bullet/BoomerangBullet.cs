using _Game.Utils;
using UnityEngine;


namespace _Game.Scripts.Weapon.Bullet
{
    public class BoomerangBullet : Bullet
    {
        private bool isBack = false;
        public override void Move()
        {
            float step = moveSpeed * Time.deltaTime;
            TF.position = Vector3.MoveTowards(TF.position, targetPoint, step);
            TF.Rotate(0f, BulletSpeed.ROTATION * Time.deltaTime, 0f);

            if (isBack)
            {
                targetPoint = owner.ThrowPoint;
            }

            if (Vector3.Distance(TF.position, targetPoint) <= 0.5f)
            {
                if (isBack)
                {
                    OnDespawn();
                }
                else
                {
                    isBack = true;
                    //moveSpeed *= 1.75f;
                }
            }
        }

        public override void SetUp()
        {
            isBack = false;
        }
    }
}

