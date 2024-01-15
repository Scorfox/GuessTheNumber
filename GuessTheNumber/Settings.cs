namespace GuessTheNumber;

public class Settings
{
    public Settings()
    {
        Game = new GameSettings();
    }
    
    public GameSettings Game { get; set; }
}

public class GameSettings
{
    public int MaxAttemptsNumber { get; set; } 
    public int MinNumber { get; set; }
    public int MaxNumber { get; set; }
}