using DikaoRpgSimulator.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DikaoRpgSimulator
{
    public class Simulator :ISimulator
    {
        public static int HeroIdSelection { get; protected set; }
        public static int BattleSimulationQty { get; protected set; }
        public static int Rounds { get; protected set; } = 0;
        public static bool MenuRepetition { get; protected set; } = true;
        public static string? MenuOption { get; protected set; }
        public static HeroEntity? CurrentHero { get; protected set; }

        public static IHeroRepository HeroRepository;
        public static IEngine Engine;

        public Simulator([FromServices] IHeroRepository _heroRepository, [FromServices] IEngine _engine)
        {
            Engine = _engine;
            HeroRepository = _heroRepository;

        }
        public Simulator(int heroId, int roundQty, [FromServices] IHeroRepository _heroRepository, [FromServices] IEngine _engine)
        {
            HeroIdSelection = heroId;
            Rounds = roundQty;
            HeroRepository = _heroRepository;
            Engine = _engine;
        }

        public void BattleEngine(HeroEntity hero, int Rounds)
        {
            CurrentHero = hero;

            if (CurrentHero != null)
            {
                if (CurrentHero.Life > 0)
                {
                    BattleSimulationQty = Rounds;
                    StartBattle(BattleSimulationQty);

                }
            }

        }
        public void StartBattle(int NumberOfBattles)
        {

            if (CurrentHero != null)
            {
                while (NumberOfBattles > 0 && CurrentHero.Life > 0)
                {
                    Engine.newBattle(CurrentHero);

                    NumberOfBattles--;

                    HeroRepository.UpdateHero(CurrentHero);

                }
            }


        }


    }

}
