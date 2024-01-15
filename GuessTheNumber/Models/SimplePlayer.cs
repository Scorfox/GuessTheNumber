namespace GuessTheNumber.Models;

public class SimplePlayer : Player
{
    public override void MakeGuess()
    {
        Console.WriteLine("SimplePlayer is making a guess.");
    }
    
    public override void Think()
    {
        Console.WriteLine("SimplePlayer is thinking.");
    }
}