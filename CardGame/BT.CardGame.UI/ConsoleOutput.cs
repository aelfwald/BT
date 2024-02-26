namespace BT.CardGame;

public class ConsoleOutput : IGameOutput
{
    public void Print(string output)
    {
        Console.WriteLine(output);  
    }
}
