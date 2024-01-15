namespace GuessTheNumber.Services.NumberRandomGenerator;

public interface INumberGeneratorService
{
    public int Generate(int min, int max);
}