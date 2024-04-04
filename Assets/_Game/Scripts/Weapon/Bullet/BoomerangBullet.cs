using _Game.Utils;
using UnityEngine;


namespace _Game.Scripts.Weapon.Bullet
{
    public class BoomerangBullet : Bullet
    {
        private bool isBack = false;
        
        
        public override void Move()
        {
            float step = 1f * Time.deltaTime;
            TF.position = Vector3.MoveTowards(TF.position, targetPoint, step);
            TF.Rotate(0f, BulletSpeed.ROTATION * Time.deltaTime, 0f);

            if (isBack)
            {
                //Debug.Log("Change target point");
                targetPoint = owner.ThrowPoint;
                Debug.Log(targetPoint);
            }

            if (Vector3.Distance(TF.position, targetPoint) < maxFlyDistance)
            {
                if (isBack)
                {
                    OnDespawn();
                }
                else
                {
                    isBack = true;
                    Debug.Log("Change target point");
                    //moveSpeed *= 1.75f;
                }
            }
        }

        public override void SetUp()
        {
            isBack = false;
            Debug.Log(targetPoint);
        }
    }
}

