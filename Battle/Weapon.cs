using System;

namespace Battle
{
    public class Weapon
    {
        public enum EWeaponType
        {
            Axe,
            Sword,
            Spear,
            BareFist
        }

        public int Damage
        {
            get
            {
                switch (Type)
                {
                    case EWeaponType.Axe:
                        return 3;
                    case EWeaponType.Sword:
                        return 2;
                    case EWeaponType.Spear:
                        return 2;
                    case EWeaponType.BareFist:
                        return 1;
                }

                throw new Exception("Invalid weapon type specified "+Type);
            }
        }

        public EWeaponType Type { get; set; }
    }
}