namespace BT.CardGame;

/// <summary>
/// A service that builds a deck of cards
/// </summary>
public interface IDeckBuilder
{
    /// <summary>
    /// Builds the deck
    /// </summary>
    Deck BuildDeck();
}
