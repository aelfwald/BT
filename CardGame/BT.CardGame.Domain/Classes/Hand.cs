
namespace BT.CardGame;

/// <summary>
/// A hand of cards
/// </summary>
public class Hand
{
    private readonly List<Card> _cards = [];

    /// <summary>
    /// A <see cref="IEnumerable{T} of <see cref="Card"/> in the hand"/>
    /// </summary>
    public IEnumerable<Card> Cards
    {
        get
        {
            return _cards;
        }    
    }

    /// <summary>
    /// Addes card to the hand.
    /// </summary>
    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
}
