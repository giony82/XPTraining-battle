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
                        break;
                    case EWeaponType.Sword:
                        break;
                    case EWeaponType.Spear:
                        break;
                    case EWeaponType.BareFist:
                        break;
                }
                return 0;
            }
        }

        public EWeaponType Type { get; set; }
    }
}