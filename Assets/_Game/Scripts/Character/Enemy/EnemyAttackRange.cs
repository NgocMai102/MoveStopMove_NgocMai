using System.Collections;
using System.Collections.Generic;
using _Framework;
using UnityEngine;

namespace _Game.Scripts.Character.Enemy
{
    public class EnemyAttackRange : AttackRange
    {
        protected override void CharacterEnterRange(Collider other)
        {
            Character otherCharacter = Cache<Character>.GetComponent(other);
            
            if (otherCharacter != owner)
            {
                owner.OnCharacterEnterRange(otherCharacter);
            }
                
        }

        protected override void CharacterExitRange(Collider other)
        {
            Character otherCharacter = Cache<Character>.GetComponent(other);

            if (otherCharacter != owner)
            {
                owner.OnCharacterExitRange(otherCharacter);
            }
        }
    }
}

