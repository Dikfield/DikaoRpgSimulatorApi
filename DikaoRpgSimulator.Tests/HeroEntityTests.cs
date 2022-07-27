using DikaoRpgSimulator.Data;
using DikaoRpgSimulator.Data.Repository;
using Moq;

namespace DikaoRpgSimulator.Tests
{
    public class HeroEntityTests
    {
        private readonly HeroFactory _heroCreator;
        private readonly HeroEntity _hero;
        public HeroEntityTests()
        {
            _heroCreator = new HeroFactory();
            _hero = _heroCreator.Create("Warrior", "HeroTest");
        }

        [Theory]
        [InlineData("Warrior", "hero", 0)]
        [InlineData("Archer", "hero", 0)]
        [InlineData("Mage", "hero", 0)]
        public void HeroEntityAttack_HeroCompareAttackAndMainHability_Return0(string _class, string name, int attackAndHabilityCompare)
        {
            var hero = _heroCreator.Create(_class, name);

            if (_class == "Warrior")
            {
                attackAndHabilityCompare = hero.Strength - hero.Attack;
                Assert.Equal(0, attackAndHabilityCompare);
            }
            else if (_class == "Archer")
            {
                attackAndHabilityCompare = hero.Dexterity - hero.Attack;
                Assert.Equal(0, attackAndHabilityCompare);
            }
            else
            {
                attackAndHabilityCompare = hero.Wisdom - hero.Attack;
                Assert.Equal(0, attackAndHabilityCompare);
            }

        }

        [Fact]
        public void HeroEntity_HeroXpCheckGive50_ReturnXp50()
        {
            _hero.CheckAndUpXp(50);
            Assert.Equal(50, _hero.Xp);
        }

        [Fact]
        public void HeroEntity_HeroLevelUp_ReturnLevel2()
        {
            _hero.CheckAndUpXp(150);
            _hero.CheckAndUpLevel();
            Assert.Equal(2, _hero.Level);
        }

        [Fact]
        public void HeroEntity_HeroXpIncrementLevel2_Return150()
        {
            _hero.CheckAndUpXp(150);
            _hero.CheckAndUpLevel();
            Assert.Equal(150, _hero.XpIncrement);
        }

        [Fact]
        public void HeroEntity_CheckLossLife_ReturnLife0()
        {
            _hero.LostLife(_hero.Class, _hero.Attack, 500);
            Assert.Equal(0, _hero.Life);
        }

        [Fact]
        public void HeroEntity_HeroMaxLifeCheck_MaxLifeMoreThanLife()
        {
            _hero.LostLife(_hero.Class, _hero.Attack, 100);
            Assert.NotEqual(_hero.MaxLife, _hero.Life);
        }

        [Fact]
        public void HeroEntity_CheckDamage500_ReturnIsNotAlive()
        {
            _hero.LostLife(_hero.Class, _hero.Attack, 500);
            Assert.False(_hero.IsAlive());
        }


    }
}
