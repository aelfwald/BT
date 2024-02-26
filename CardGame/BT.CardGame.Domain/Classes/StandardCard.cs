namespace BT.CardGame;

/// <summary>
/// Defines a standard playing card
/// </summary>
/// <param name="rank">The card rank</param>
/// <param name="suit">The card suit</param>
public class StandardCard(string rank, string suit) : Card
{
    /// <summary>
    /// The rank
    /// </summary>
    public string Rank
    {
        get;
    } = rank;

    /// <summary>
    /// The suit
    /// </summary>
    public string Suit
    {
        get;
    } = suit;


    /// <summary>
    /// The card name
    /// </summary>
    public override string Name
    {
        get
        {
            return Rank + Suit;
        }
    }
}
