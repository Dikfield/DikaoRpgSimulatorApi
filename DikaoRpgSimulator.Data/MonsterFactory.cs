using DikaoRpgSimulator.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DikaoRpgSimulator.Data
{
    public class MonsterFactory: IMonsterFactory
    {

        public MonsterFactory()
        {

        }
        public MonsterEntity Create()
        {
            var random = new Random();
            var monster = new MonsterEntity();

            if (random.Next(2) == 1)
            {
                monster.Type = "Orc";
                monster.GiveXp = 60;
                monster.Life = random.Next(10, 31);
                monster.Wisdom = 5;
                monster.Strength = random.Next(10,15);
                monster.Dexterity = random.Next(10, 13);
                monster.Attack = monster.Strength;
                monster.Defense = monster.Strength;
                return monster;
            }
            else
            {
                monster.Type = "Goblin";
                monster.GiveXp = 20;
                monster.Life = random.Next(5,16);
                monster.Wisdom = 3;
                monster.Strength = random.Next(5,9);
                monster.Dexterity = random.Next(3,7);
                monster.Attack = monster.Dexterity;
                monster.Defense = monster.Strength;
                return monster;
            }
            
        }

        public MonsterEntity GetMonster()
        {
            throw new NotImplementedException();
        }
    }
}
