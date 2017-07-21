using System;

namespace Battle
{
    public class Soldier
    {
        private Weapon _weapon;
        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            _weapon=new Weapon() {Type = Weapon.EWeaponType.BareFist};
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

        public bool Fight(Soldier enemy)
        {
            bool isAtacker = new Random().Next(1,2) % 2 == 0;

            if (_weapon.Damage == enemy._weapon.Damage)
            {
                return isAtacker;
            }
            return _weapon.Damage > enemy._weapon.Damage;
        }
    }
}