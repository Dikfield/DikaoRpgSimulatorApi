using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.Data
{
    public abstract class Char
    {
        public int Life { get; internal set; }


        public int Wisdom { get; internal set; }
        public int Strength { get; internal set; }
        public int Dexterity { get; internal set; }
        public int Attack { get; internal set; }
        public int Defense { get; internal set; }

              

        public abstract int Damage(string heroClass, int heroAttack, int monsterAttack);
        public abstract bool IsAlive();
        public abstract void LostLife(string heroClass, int heroAttack, int monsterAttack);

    }
}
