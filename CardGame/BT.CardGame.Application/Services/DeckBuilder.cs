
namespace BT.CardGame;

/// <summary>
/// The deck builder
/// </summary>
public class DeckBuilder(
    ICardProvider packProvider) : IDeckBuilder
{
    private readonly ICardProvider _packProvider = packProvider;

    public Deck BuildDeck()
    {
        Deck deck = new();

        foreach (Card card in _packProvider.GetCards())
        {
            deck.Add(card);
        }

        return deck;
    }
}
