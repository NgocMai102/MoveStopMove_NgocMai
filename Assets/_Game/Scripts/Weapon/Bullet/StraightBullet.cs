using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Weapon.Bullet;
using UnityEngine;

namespace _Game.Scripts.Weapon.Bullet
{
    public class StraightBullet : Bullet
    {
        public void OnInit(Character.Character owner, Vector3 targetPoint, float size)
        {
            base.OnInit(owner, targetPoint, size);
            
        }
    }
}

