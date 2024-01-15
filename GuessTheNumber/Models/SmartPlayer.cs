namespace GuessTheNumber.Models;

public class SmartPlayer : Player
{
    public override void MakeGuess()
    {
        Console.WriteLine("SmartPlayer is making a guess.");
    }
    
    public override void Think()
    {
        Console.WriteLine("SmartPlayer is thinking.");
    }
}