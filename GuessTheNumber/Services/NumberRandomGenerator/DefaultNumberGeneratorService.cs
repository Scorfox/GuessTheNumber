namespace GuessTheNumber.Services.NumberRandomGenerator;

public class DefaultNumberGeneratorService : INumberGeneratorService
{
    public int Generate(int min, int max)
    {
        var rand = new Random();
        return rand.Next(min, max);
    }
}