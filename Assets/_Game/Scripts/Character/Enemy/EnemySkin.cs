using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Character;
using _Game.Utils;
using UnityEngine;


namespace _Game.Scripts.Character.Enemy
{
    public class EnemySkin : CharacterSkin
    {
        public override void OnInit()
        {
            base.OnInit();
            //ChangeWeapon();
            //ChangeAccessory(Utilities.RandomEnumValue<AccessoryType>());
            ChangeHat(Utilities.RandomEnumValue<HatType>());
            ChangePants(Utilities.RandomEnumValue<PantsType>());
        }
    }
}

