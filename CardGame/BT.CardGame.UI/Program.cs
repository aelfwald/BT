using BT.CardGame;

// See https://aka.ms/new-console-template for more information

do
{
    Console.WriteLine("Please input the required cards and press enter...");

    string? requestedCards = Console.ReadLine();

    if(requestedCards != string.Empty)
    {
        Console.WriteLine("");
        var cardGame = new CardGameService(
                     new DeckBuilder(
                           new CardProvider()),
                     new InputParser());

        cardGame.Play(requestedCards!, new ConsoleOutput());
        Console.WriteLine("");
    }
} while (true);












