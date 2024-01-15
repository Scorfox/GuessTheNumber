using GuessTheNumber.Enums;
using GuessTheNumber.Models;
using GuessTheNumber.Services.NumberRandomGenerator;
using GuessTheNumber.Services.Settings;

namespace GuessTheNumber.Services.Game;

public class GuessNumberGameWithHelpStrategy : IGuessNumberGameStrategy
{
    private INumberGeneratorService NumberGeneratorService { get; }
    private GameSettings GameSettings { get; }
    private int GeneratedNumber { get; set; }
    
    public Player Player { get; set; }
    
    public GuessNumberGameWithHelpStrategy(
        Player player,
        INumberGeneratorService numberGeneratorService, 
        ISettingsService settingsService)
    {
        Player = player;
        NumberGeneratorService = numberGeneratorService;
        GameSettings = settingsService.GetGameSettings();
    }

    public void Start()
    {
        var wastedAttemptsNumber = 0;
        GeneratedNumber = NumberGeneratorService.Generate(GameSettings.MinNumber, GameSettings.MaxNumber);
        
        Console.WriteLine($"The game is started! " +
                          $"Try to guess the number from {GameSettings.MinNumber} to {GameSettings.MaxNumber}. " +
                          $"You have {GameSettings.MaxAttemptsNumber} attempts.");
        
        Player.MakeGuess();
        
        while (wastedAttemptsNumber < GameSettings.MaxAttemptsNumber)
        {
            var clientResponse = Console.ReadLine();
            if (int.TryParse(clientResponse, out var clientResponseNumber))
            {
                var comparison = (Comparison)clientResponseNumber.CompareTo(GeneratedNumber);

                switch (comparison)
                {
                    case Comparison.Equal:
                        Console.WriteLine($"You win! It's {clientResponseNumber}");
                        return;
                    case Comparison.LessThan:
                        Console.WriteLine($"{clientResponseNumber} is less than the generated number");
                        break;
                    case Comparison.MoreThan:
                        Console.WriteLine($"{clientResponseNumber} is more than the generated number");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (wastedAttemptsNumber == GameSettings.MaxAttemptsNumber - 1)
                {
                    Console.WriteLine("I am kind today. Get additional attempt");
                    GameSettings.MaxAttemptsNumber++;
                }
                wastedAttemptsNumber++;
            }
            else
            {
                Console.WriteLine("Write number!");
            }
        }
    }
}