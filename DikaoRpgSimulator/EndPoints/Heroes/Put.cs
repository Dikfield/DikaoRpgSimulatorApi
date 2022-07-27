using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class Put
    {
        public static string Route => "/heroes/{id}";

        public async static Task<IResult> Action([FromRoute] int id, HeroesRequest heroesRequest, [FromServices] IHeroRepository _heroRepository)
        {

            var hero = _heroRepository.GetHeroId(id);
            if (hero == null)
                return Results.NotFound();

            string heroOldName = hero.Name;

            _heroRepository.ChangeHeroName(id, heroesRequest.Name);
                                             
            return Results.Ok($"The old name was {heroOldName} and the new name is {heroesRequest.Name}");

        }

    }
}
