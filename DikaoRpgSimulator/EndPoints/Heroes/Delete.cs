using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class Delete
    {
        public static string Route => "/heroes/{id}";


        public async static Task<IResult> Action([FromRoute] int id, [FromServices] IHeroRepository _heroRepository)
        {
            var hero = _heroRepository.GetHeroId(id);

            if (hero == null)
                return Results.BadRequest("Id is invalid");
            _heroRepository.DeleteHero(hero);
                        
            return Results.Ok($"Deleted the hero" +
                $"Name: {hero.Name} " +
                $" Class: {hero.Class}");
        }
    }
}
