using DikaoRpgSimulator.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DikaoRpgSimulator.Domain
{
    public class Engine: IEngine
    {
        public IHeroRepository HeroRepository { get; set; }
        public HeroEntity Hero { get; set; }
        public IBattleCreator Battle;
        public IMonsterFactory MonsterFactory { get; set; }

        private List<MonsterEntity> Monsters = new List<MonsterEntity>();

        public Engine([FromServices] IHeroRepository _heroRepository, [FromServices] IBattleCreator _battle, [FromServices] IMonsterFactory _monsterfactory)
        {
            HeroRepository = _heroRepository;
            Battle = _battle;
            MonsterFactory = _monsterfactory;
        }

        public void newBattle(HeroEntity hero)
        {
            Battle.HandleBattle(hero, MonsterGenerator(hero.Level));
        }
        public List<MonsterEntity> MonsterGenerator(int heroLevel)
        {
            for (int i = 0; i < heroLevel; i++)
            {
                var monster = MonsterFactory.Create();
                Monsters.Add(monster);
            }

            return Monsters;

        }

    }
}
