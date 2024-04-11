using _Game.Utils;

namespace _Game.Scripts.Character.Enemy
{
    public class EnemySkin : CharacterSkin
    {
        public override void OnInit(Character character)
        {
            base.OnInit(character);
            ChangeWeapon(Utilities.RandomEnumValue<WeaponType>());
            //ChangeAccessory(Utilities.RandomEnumValue<AccessoryType>());
            ChangeHat(Utilities.RandomEnumValue<HatType>());
            ChangePants(Utilities.RandomEnumValue<PantsType>());
        }
    }
}

