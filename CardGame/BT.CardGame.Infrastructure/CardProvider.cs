
namespace BT.CardGame;

/// <summary>
/// Proves a full pack of cards
/// </summary>
public class CardProvider : ICardProvider
{
    public IEnumerable<Card> GetCards()
    {
        List<string> suits = ["C", "D", "H", "S"];
        List<string> ranks = ["2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"];

        foreach(var suit in suits)
        {
            foreach(var rank in ranks)
            {
                yield return new StandardCard(rank, suit);
            }
        }

        yield return new Joker();
        yield return new Joker();

    }
}
