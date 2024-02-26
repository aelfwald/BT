namespace BT.CardGame;

/// <summary>
/// Defines a service that provides a pack of cards
/// </summary>
public interface ICardProvider
{
    /// <summary>
    /// Gets the cards
    /// </summary>
    /// <returns>A pack of cards</returns>
    IEnumerable<Card> GetCards();
}
