using DikaoRpgSimulator.Data.Repository;

namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class Post
    {
        public static string Route => "/heroes";
        public static IResult Action(HeroesRequest heroesRequest, [FromServices] IHeroFactory _heroFactory)
        {
            var hero = _heroFactory.Create(heroesRequest.Class, heroesRequest.Name);
            _heroFactory.SaveHero(hero);
            var response = new string[] {
                $"Name:{hero.Name}", $"Class:{hero.Class}"};

            return Results.Created($"/heroes {response}", response);

        }

    }
}
