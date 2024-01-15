using GuessTheNumber.Models;
using GuessTheNumber.Services.Game;
using GuessTheNumber.Services.NumberRandomGenerator;
using GuessTheNumber.Services.Settings;

IGuessNumberGameStrategy game = new GuessNumberGameWithHelpStrategy(
    new SmartPlayer(),
    new CryptoNumberGeneratorService(), 
    new SettingsService("appsettings.json")
    );

game.Start();
