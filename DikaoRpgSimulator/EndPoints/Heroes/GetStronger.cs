using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class GetStronger
    {
        public static string Route => "/strongerHero/{_class}";


        public static IResult Action([FromRoute] string _class, [FromServices] IHeroRepository _heroRepository)
        {
            var hero = _heroRepository.GetStrongerHero(_class);

            if (hero == null)
                return Results.BadRequest("No database");

            var response = new HeroesResponse(hero.Name, hero.Id, hero.Class,
                hero.Xp, hero.Level, hero.Life, hero.Attack, hero.Attack);

            if (response == null)
                return Results.Ok("There is not this class");

            return Results.Ok(response);
        }
    }
}
