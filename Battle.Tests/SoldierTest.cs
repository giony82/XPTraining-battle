using System;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Battle
{
    public class SoldierTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void construction_ASoldierMustHaveAName_CannotBeBlank(string name)
        {
            ((Action) (() => new Soldier(name))).ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void construction_ASoldierMustHaveAName()
        {
            // test commit
            var soldier = new Soldier("name");

            soldier.Name.Should().Be("name");
        }

        [Fact]
        public void construction_ASoldierMustHaveDefaultWeapon()
        {
            var soldier = new Soldier("name");

            soldier.Weapon.Type.Should().Be(Weapon.EWeaponType.BareFist);
        }

        [Fact]
        public void construction_ASoldierMustHaveNameAndWeapon()
        {
            var soldier = new Soldier("name", Weapon.EWeaponType.Axe);

            soldier.Name.Should().Be("name");
            soldier.Weapon.Type.Should().Be(Weapon.EWeaponType.Axe);
        }

        [Fact]
        public void Soldier_InvalidWeaponTypeTest()
        {
            var john = new Soldier("john");
            john.Weapon.Type = (Weapon.EWeaponType) 100;

            Assert.Throws<Exception>(() => john.Weapon.Damage);
        }

        [Fact]
        public void Soldier_whenAttacksAnotherSoldier_ShouldLose()
        {
            var john = new Soldier("john");
            var smith = new Soldier("smith");

            john.Weapon.Type = Weapon.EWeaponType.BareFist;
            smith.Weapon.Type = Weapon.EWeaponType.Axe;

            var result = john.Fight(smith, A.Fake<IAttacker>());

            result.Should().Be(smith);
        }

        [Fact]
        public void Soldier_whenAttacksAnotherSoldier_ShouldWin()
        {
            var john = new Soldier("john");
            var smith = new Soldier("smith");

            john.Weapon.Type = Weapon.EWeaponType.Axe;
            smith.Weapon.Type = Weapon.EWeaponType.BareFist;

            var result = john.Fight(smith, A.Fake<IAttacker>());

            result.Should().Be(john);
        }

        [Fact]
        public void Soldier_whenCombatantsMatchedAttackerWins()
        {
            var john = new Soldier("john");
            var smith = new Soldier("smith");

            john.Weapon.Type = Weapon.EWeaponType.BareFist;
            smith.Weapon.Type = Weapon.EWeaponType.BareFist;

            var attacker = A.Fake<IAttacker>();
            A.CallTo(() => attacker.GetAttacker(john, smith)).Returns(john);

            var result = john.Fight(smith, attacker);

            result.Should().Be(john);
        }

        [Fact]
        public void Soldier_whenCombatantsMatchedIsNotAttackerLoose()
        {
            var john = new Soldier("john");
            var smith = new Soldier("smith");

            john.Weapon.Type = Weapon.EWeaponType.BareFist;
            smith.Weapon.Type = Weapon.EWeaponType.BareFist;

            var attacker = A.Fake<IAttacker>();
            A.CallTo(() => attacker.GetAttacker(john, smith)).Returns(smith);

            var result = john.Fight(smith, attacker);

            result.Should().Be(smith);
        }
    }
}