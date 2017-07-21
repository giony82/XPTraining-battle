using System;
using Xunit;
using FluentAssertions;

namespace Battle
{
    public class SoldierTest
    {

        [Fact]
        public void construction_ASoldierMustHaveAName()
        {
            // test commit
            Soldier soldier = new Soldier("name");

            soldier.Name.Should().Be("name");
        }

        [Fact]
        public void Solider_whenAttacksAnotherSolider_ShouldWin()
        {
            Soldier john=new Soldier("john");
            Soldier smith=new Soldier("smith");
            var result=john.Fight(smith);

            result.Should().Be(true);
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void construction_ASoldierMustHaveAName_CannotBeBlank(string name)
            => ((Action)(() => new Soldier(name))).ShouldThrow<ArgumentException>();


        [Fact]
        public void construction_ASoldierMustHaveDefaultWeapon()
        {
            Soldier soldier = new Soldier("name");

            soldier.Weapon.Type.Should().Be(Weapon.EWeaponType.BareFist);
        }

        [Fact]
        public void construction_ASoldierMustHaveNameAndWeapon()
        {
            Soldier soldier = new Soldier("name", Weapon.EWeaponType.Axe);

            soldier.Name.Should().Be("name");
            soldier.Weapon.Type.Should().Be(Weapon.EWeaponType.Axe);
        }
    }
}