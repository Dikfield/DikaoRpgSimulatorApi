namespace DikaoRpgSimulator.Data
{
    public class BattleData
    {
        public int Id { get; set; }
        public int HeroEntityId { get; set; }
        public int MonsterQty { get; set; }
        public int Rounds { get; set; }
        public virtual HeroEntity? Hero { get; set; }

    }
}
