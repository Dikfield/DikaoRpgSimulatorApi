namespace DikaoRpgSimulator.Data
{
    public class HeroEntity : Char
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public string? Class { get; set; }
        public int Xp { get; internal set; }
        public int XpIncrement { get; internal set; }
        public int Level { get; internal set; }
        public int MaxLife { get; internal set; }

        public HeroEntity()
        {


        }
        public void AttackAndDefenseCheck()
        {
            switch (Class)
            {
                case "Archer":
                    Attack = Dexterity;
                    break;

                case "Mage":
                    Attack = Wisdom;
                    break;
                case "Warrior":
                    Attack = Dexterity;
                    break;
            }
            Defense = Dexterity;
        }
        public void CheckAndUpXp(int xpMonster)
        {
            Xp += xpMonster;
        }

        public void CheckAndUpLevel()
        {
            if (Xp >= 100 + XpIncrement)
            {
                Level++;
                XpIncrement += 100;
                Xp = 0;
                MaxLife += 20;
                Life = MaxLife;
                Dexterity++;
                Strength++;
                Wisdom++;

            }

        }


        public override int Damage(string heroClass, int heroAttack, int monsterAttack)
        {
            if (monsterAttack - Defense > 0)
                return monsterAttack - Defense;

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
            if (heroClass == null)
                return;
            Life -= Damage(heroClass, heroAttack, monsterAttack);
            if (Life < 0)
                Life = 0;
        }
    }
}
