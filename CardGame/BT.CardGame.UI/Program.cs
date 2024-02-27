using BT.CardGame;

// See https://aka.ms/new-console-template for more information

var cardGame = new CardGameService(
             new DeckBuilder(
                   new CardProvider()),
             new InputParser());

do
{
    Console.WriteLine("Please input the required cards and press enter...");

    string? requestedCards = Console.ReadLine();

    if(requestedCards != string.Empty)
    {
        Console.WriteLine("");
        cardGame.Play(requestedCards!, new ConsoleOutput());
        Console.WriteLine("");
    }
} while (true);












