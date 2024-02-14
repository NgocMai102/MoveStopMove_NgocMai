using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using _Game.Utils;
using UnityEngine;

namespace _Game.Scripts.Character
{
    public abstract class AttackRange : GameUnit
    {
        protected Character owner;

        public void OnInit(Character character)
        {
            owner = character;
            TF.localScale = Vector3.one * owner.AttackRangeRadius;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagName.CHARACTER))
            {
                CharacterEnterRange(other);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagName.CHARACTER))
            {
                CharacterExitRange(other);
            }
        }
        
        protected abstract void CharacterEnterRange(Collider other);
        protected abstract void CharacterExitRange(Collider other);
    }
}
