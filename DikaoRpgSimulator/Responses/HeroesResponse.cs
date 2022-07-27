namespace DikaoRpgSimulator.Data.Responses
{
    public record HeroesResponse(string? Name, int Id, string? Class, int Xp, int Level, int Life, int Attack, int Defense);
    
}
