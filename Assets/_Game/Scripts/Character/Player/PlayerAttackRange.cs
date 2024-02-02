using System.Collections;
using System.Collections.Generic;
using _Framework;
using UnityEngine;

namespace _Game.Scripts.Character.Player
{
    public class PlayerAttackRange : AttackRange
    {
        protected override void CharacterEnterRange(Collider other)
        {
            Enemy.Enemy enemy = Cache<Enemy.Enemy>.GetComponent(other);

            if (enemy != null)
            {
                enemy.ShowCircleIndicator();
                owner.OnCharacterEnterRange(enemy);
            }
        }

        protected override void CharacterExitRange(Collider other)
        {
            Enemy.Enemy enemy = Cache<Enemy.Enemy>.GetComponent(other);

            if (enemy != null)
            {
                enemy.HideCircleIndicator();
                owner.OnCharacterExitRange(enemy);
            }
        }
    }
}

