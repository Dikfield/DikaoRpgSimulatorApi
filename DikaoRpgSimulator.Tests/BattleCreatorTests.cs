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
    public class BattleCreatorTests
    {

        private BattleCreator _battle;
        private HeroFactory _heroFactory;
        private MonsterFactory _monsterFactory;
        private List<MonsterEntity> _monsterList;

        public BattleCreatorTests()
        {
            _heroFactory = new HeroFactory();
            _monsterFactory = new MonsterFactory();
            _monsterList = new List<MonsterEntity>();
            _battle = new BattleCreator();
        }
        [Fact]
        public void EngineMonsterCreation_HeroLevel2_Return2()
        {
            
            var hero = _heroFactory.Create("Archer", "HeroTest");
            var monster = _monsterFactory.Create();

            
            _monsterList.Add(monster);
               int oldXp = hero.Xp;

            _battle.HandleBattle(hero,_monsterList);

                int newXp = hero.Xp;

                if(hero.Life>0)
                    Assert.NotEqual(oldXp, newXp);
                else
                    Assert.Equal(oldXp, newXp);
            
        }
    }
}
