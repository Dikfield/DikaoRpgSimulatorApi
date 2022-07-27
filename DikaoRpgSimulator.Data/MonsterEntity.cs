
using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.Data
{
    public class MonsterEntity : Char
    {
        public int Id { get; init; }
        public string? Type { get; internal set; }
        public int GiveXp { get; internal set; }

        public MonsterEntity()
        {

        }

        public override int Damage(string? heroClass, int heroAttack, int monsterAttack)
        {
            if (heroClass == "Mage")
                return heroAttack;

            else if (heroAttack - Defense > 0)
                return heroAttack - Defense;

            else
                return 1;

        }

        public override bool IsAlive()
        {
            if (Life > 0)
                return true;
            return false;
        }

        public override void LostLife(string? heroClass, int heroAttack, int monsterAttack)
        {
            Life -= Damage(heroClass, heroAttack, monsterAttack);
            if (Life < 0)
                Life = 0;
        }
    }
}
