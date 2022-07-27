using DikaoRpgSimulator.Data;
using DikaoRpgSimulator.Domain;

namespace DikaoRpgSimulator.Tests
{
    public class MonsterFactoryTests
    {
        private MonsterFactory _monsterFactory;
        private List<MonsterEntity> _monsterList;
        public MonsterFactoryTests()
        {
            _monsterFactory = new MonsterFactory();
        }
        [Fact]
        public void MonsterFactory_1MonsterCreation_Return1()
        {
            _monsterList = new List<MonsterEntity>();

            _monsterList.Add(_monsterFactory.Create());

            Assert.Equal(1, _monsterList.Count);
        }

        [Fact]
        public void MonsterFactory_MonsterTypeGoblinOrOrc_ReturnGoblinOrOrc()
        {
            var monster = _monsterFactory.Create();

            if(monster.Type == "Orc")
                Assert.Equal("Orc", monster.Type);
            else
                Assert.Equal("Goblin", monster.Type);

        }

    }
}