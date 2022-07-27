using DikaoRpgSimulator.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DikaoRpgSimulator.Domain
{
    public class BattleCreator:IBattleCreator
    {
        public HeroEntity Hero { get; set; }
        public List<MonsterEntity> Monsters { get; set; }
        public IHeroRepository HeroRepository { get; set; }

        public BattleCreator()
        {

        }
        public BattleCreator([FromServices] IHeroRepository _heroRepository)
        {
            HeroRepository = _heroRepository;
        }
        public void HandleBattle(HeroEntity hero, List<MonsterEntity> monster)
        {
            Hero = hero;
            Monsters = monster;

            Monsters.First().LostLife(Hero.Class, Hero.Attack, Monsters.First().Attack);

            if (Monsters.First().IsAlive())
            {
                while (Hero.IsAlive() && Monsters.Any())
                {
                    foreach (MonsterEntity _monster in Monsters)
                    {
                        Hero.LostLife(Hero.Class, Hero.Attack, Monsters.First().Attack);
                    };

                    Monsters.First().LostLife(Hero.Class, Hero.Attack, Monsters.First().Attack);
                    if (!Monsters.First().IsAlive())
                    {
                        Hero.CheckAndUpXp(Monsters.First().GiveXp);
                        Hero.CheckAndUpLevel();
                        Hero.AttackAndDefenseCheck();
                        Monsters.Remove(Monsters.First());

                    }
                }
            }

            if (Hero.IsAlive())
            {
                for (int i = 0; i < Monsters.Count; i++)
                {
                    Hero.CheckAndUpXp(Monsters.First().GiveXp);
                    Hero.CheckAndUpLevel();
                    Hero.AttackAndDefenseCheck();
                    Monsters.Remove(Monsters.First());
                }


            }
            Hero.CheckAndUpLevel();
            Console.WriteLine("\nResult are\n");


        }
    }
}
