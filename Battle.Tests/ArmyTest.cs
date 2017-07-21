using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {
        [Fact]
        public void when_CanCreateArmyWithSoldiers()
        {
            var army=new Army();
            List<Soldier> soldiers =new List<Soldier>
            {
                new Soldier("John"),
                new Soldier("Smith", Weapon.EWeaponType.Spear)
            };
            army.AddSoldiers(soldiers);
            army.Soldiers.Should().Contain(soldiers);
        }

        [Fact]
        public void when_FrontManShouldBeFirstInSoldiersList()
        {
            var army = new Army();
            var soldier = new Soldier("John");
            List<Soldier> soldiers = new List<Soldier>
            {
                soldier,
                new Soldier("Smith", Weapon.EWeaponType.Spear)
            };
            army.AddSoldiers(soldiers);

            var frontMan = army.GetFrontMan();
            frontMan.Should().Be(soldier);
        }
    }
}
