namespace BT.CardGame;

/// <summary>
/// Defines a deck of cards
/// </summary>
public class Deck
{
    private readonly List<Card> _cards = [];

    /// <summary>
    /// Adds a card to the deck
    /// </summary>
    /// <param name="card"></param>
    public void Add(Card card)
    {
        _cards.Add(card);
    }

    /// <summary>
    /// Deals a card from the deck
    /// </summary>
    /// <param name="cardName">name of the card to be dealt</param>
    /// <param name="card">the card that is dealt</param>
    /// <param name="errorMessage">error message if deal was unsuccessful</param>
    /// <returns></returns>
    public bool TryDealCard(
        string cardName,
        out Card? card,
        out string errorMessage)
    {
        errorMessage = "";

        card = _cards.FirstOrDefault(c => c.Name == cardName);

        if (card == null)
        {
            errorMessage = cardName == "JK"
                    ? "A hand cannot contain more than two Jokers"
                     : "Cards cannot be duplicated";
            return false;
        }

        _cards.Remove(card);

        return true;
    }
}
