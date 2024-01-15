using System.Security.Cryptography;

namespace GuessTheNumber.Services.NumberRandomGenerator;

public class CryptoNumberGeneratorService  : INumberGeneratorService
{
    public int Generate(int min, int max)
    {
        if (min > max)
            throw new ArgumentException("Min value must be less than or equal to Max value.");

        var range = max - min + 1;

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            var randomNumberBytes = new byte[4];
            rng.GetBytes(randomNumberBytes);
            var randomNumber = Math.Abs(BitConverter.ToInt32(randomNumberBytes, 0));
            return min + randomNumber % range;
        }
    }
}