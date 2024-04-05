using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using UnityEngine;

namespace _Game.Scripts.Weapon
{
    public class Weapon : GameUnit
    {
        [SerializeField] private PoolType bulletType;

        private Character.Character owner;

        public void SpawnBullet(Vector3 target, Character.Character owner)
        {
            Bullet.Bullet newBullet = SimplePool.Spawn<Bullet.Bullet>(bulletType, TF.position, Quaternion.identity);
            newBullet.OnInit(owner, target, owner.Size);
        }
    }
}

