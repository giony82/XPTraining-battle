using System;

namespace Battle
{
    public interface IAttacker
    {
        bool IsAttacker();
    }

    public class Soldier
    {
        public Weapon Weapon { get; }
        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            Weapon = new Weapon() { Type = Weapon.EWeaponType.BareFist };
        }
        public Soldier(string name, Weapon.EWeaponType weaponType)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            Weapon = new Weapon() { Type = weaponType };
        }

        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());

        public string Name { get; }

        public bool Fight(Soldier enemy, IAttacker attacker)
        {
            if (Weapon.Damage == enemy.Weapon.Damage)
            {
                return attacker.IsAttacker();
            }
            return Weapon.Damage > enemy.Weapon.Damage;
        }
    }
}