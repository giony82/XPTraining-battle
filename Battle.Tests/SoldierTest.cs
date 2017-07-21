using System;
using FakeItEasy;
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
        public void Soldier_InvalidWeaponTypeTest()
        {
            Soldier john = new Soldier("john");
            john.Weapon.Type = (Weapon.EWeaponType)100;

            Assert.Throws<Exception>(() => john.Weapon.Damage);
        }

        [Fact]
        public void Soldier_whenAttacksAnotherSoldier_ShouldWin()
        {
            Soldier john = new Soldier("john");
            Soldier smith = new Soldier("smith");

            john.Weapon.Type = Weapon.EWeaponType.Axe;
            smith.Weapon.Type = Weapon.EWeaponType.BareFist;

            var result = john.Fight(smith,A.Fake<IAttacker>());

            result.Should().Be(true);
        }

        [Fact]
        public void Soldier_whenAttacksAnotherSoldier_ShouldLose()
        {
            Soldier john = new Soldier("john");
            Soldier smith = new Soldier("smith");

            john.Weapon.Type = Weapon.EWeaponType.BareFist;
            smith.Weapon.Type = Weapon.EWeaponType.Axe;

            var result = john.Fight(smith, A.Fake<IAttacker>());

            result.Should().Be(false);
        }

        [Fact]
        public void Soldier_whenCombatantsMatchedAttackerWins()
        {
            Soldier john = new Soldier("john");
            Soldier smith = new Soldier("smith");

            john.Weapon.Type = Weapon.EWeaponType.BareFist;
            smith.Weapon.Type = Weapon.EWeaponType.BareFist;

            var attacker = A.Fake<IAttacker>();
            A.CallTo(() => attacker.IsAttacker()).Returns(true);

            bool result = john.Fight(smith, attacker);

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