using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Models;

public abstract class Player : IMakeGuess, IAbleToThink
{
    public virtual void MakeGuess()
    {
        Console.WriteLine("Player is making a guess.");
    }

    public virtual void Think()
    {
        Console.WriteLine("Player is thinking.");
    }
}