using GuessTheNumber.Models;

namespace GuessTheNumber.Services.Game;

public interface IGuessNumberGameStrategy
{
    public void Start();
    public Player Player { get; set; }
}