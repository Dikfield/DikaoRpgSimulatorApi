using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Battles
{
    public class GetLast
    {
        public static string Route => "/Lastbattle";


        public static IResult Action([FromServices] IBattleRepository _battleRepository)
        {
            var battle = _battleRepository.GetLastBattle();

            if (battle == null)
                return Results.BadRequest("No data");

            var response = new BattlesResponse(battle.Id, battle.HeroEntityId,
                battle.MonsterQty, battle.Hero) ;



            return Results.Ok(response);
        }
    }
}
