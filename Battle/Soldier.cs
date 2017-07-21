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
    }
}