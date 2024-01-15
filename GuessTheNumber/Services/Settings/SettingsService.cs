using Microsoft.Extensions.Configuration;

namespace GuessTheNumber.Services.Settings;

public class SettingsService : ISettingsService
{
    private GuessTheNumber.Settings Settings { get; } = new();

    public SettingsService(string configPath)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(configPath)
            .Build();

        config.GetSection("Settings").Bind(Settings);
    }
    
    public GameSettings GetGameSettings()
    {
        return Settings.Game;
    }
}