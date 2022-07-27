using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class GetAll
    {
        public static string Route => "/heroes";


        public static IResult Action([FromServices] IHeroRepository _heroRepository)
        {
            
            if (_heroRepository.GetAllHero() == null)
                return Results.BadRequest("No database");

            var heroes = _heroRepository.GetAllHero();                  
            var response = heroes.Select(c => new HeroesResponse (c.Name, c.Id, c.Class,
                c.Xp, c.Level, c.Life, c.Attack, c.Defense));

            return Results.Ok(response);
        }
    }
}
