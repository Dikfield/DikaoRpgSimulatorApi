using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class PostNew
    {
        public static string Route => "/battles";

        public async static Task<IResult> Action(BattlesRequest battlesRequest, [FromServices] IBattleRepository _battleRepository, [FromServices] IHeroRepository _heroRepository, [FromServices] ISimulator _simulator )
        {
            
            //criar repositório usando o contexto, repositório classe, não interface
            //a partir daqui usar o repositório e não o contexto.
            var hero = _heroRepository.GetHeroId(battlesRequest.HeroId);

            if (hero == null)
                return Results.BadRequest("Hero Id doesnt exist");

            else if (CheckRoundQty(battlesRequest))
                return Results.BadRequest("Invalid quantity of rounds");

            else if (hero.Life > 0)
            {
                //Passar o hero repositório para simulator.
                //O simulator vai enxergar o Hero repositório como IHero repositório (interface)

                _simulator.BattleEngine(hero, battlesRequest.RoundQty);

                var battleData = new BattleData
                {
                    HeroEntityId = battlesRequest.HeroId,
                    Rounds = battlesRequest.RoundQty,
                    Hero = hero
                };
                _battleRepository.SaveBattle(battleData);

                return Results.Created($"/battles Hero {battleData.Hero.Name}", battleData.Hero.Name);
            }
            return Results.BadRequest("The hero is dead");
        }
        private static bool CheckRoundQty(BattlesRequest battlesRequest) =>
            battlesRequest.RoundQty > 100 || battlesRequest.RoundQty <= 0;
            
        
    }
}
