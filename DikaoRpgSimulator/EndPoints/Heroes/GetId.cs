using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class GetId
    {
        public static string Route => "/heroes/{id}";

        public static IResult Action([FromRoute] int id, [FromServices] IHeroRepository _heroRepository)
        {
            var hero = _heroRepository.GetHeroId(id);

            if (hero == null)
                return Results.BadRequest("No database");

            var response = new HeroesResponse (hero.Name,hero.Id, hero.Class,
                hero.Xp, hero.Level, hero.Life, hero.Attack, hero.Attack);

            return Results.Ok(response);
        }
    }
}
