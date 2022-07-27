using DikaoRpgSimulator.Data;
using DikaoRpgSimulator.Data.Repository;
using DikaoRpgSimulator.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikaoRpgSimulator.Tests
{
    public class HeroFactoryTests
    {
        private HeroFactory _heroFactory;

        public HeroFactoryTests()
        {
            _heroFactory = new HeroFactory();
        }
        [Fact]
        public void HeroFactory_CreateHero_ReturnHero()
        {
            var hero = _heroFactory.Create("Mage", "Hero1");
            Assert.NotNull(hero);
        }

        [Fact]
        public void HeroFactory_CreateMage_ReturnMage()
        {
            var hero = _heroFactory.Create("Mage", "Hero1");
            Assert.Equal("Mage", hero.Class);
        }
        [Fact]
        public void HeroFactory_CreateNameHero1_ReturnNameHero1()
        {
            var hero = _heroFactory.Create("Mage", "Hero1");
            Assert.Equal("Hero1", hero.Name);
        }
    }
}
