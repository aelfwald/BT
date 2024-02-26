namespace BT.CardGame;

/// <summary>
/// Scores a hand of cards
/// </summary>
public class HandScorer
{
    private readonly Dictionary<string, int> _suitScores = new()
    {
        {"C", 1},
        {"D", 2},
        {"H", 3},
        {"S", 4}
    };

    private readonly Dictionary<string, int> _rankScores = new()
    {
       {"2", 2},
       {"3", 3},
       {"4", 4},
       {"5", 5},
       {"6", 6},
       {"7", 7},
       {"8", 8},
       {"9", 9},
       {"T", 10},
       {"J", 11},
       {"Q", 12},
       {"K", 13},
       {"A", 14}
    };

    /// <summary>
    /// Score the hand
    /// </summary>
    /// <param name="hand">The hand to be scored</param>
    /// <returns>The score of the hand</returns>
    public int Score(Hand hand)
    {

        int numberOfJokers = 0;
        int score = 0;

        foreach (Card card in hand.Cards)
        {

            if (card is StandardCard standardCard)
            {
                int rankScore = _rankScores[standardCard.Rank];
                int suitScore = _suitScores[standardCard.Suit];

                score += rankScore * suitScore;
            }
            else if (card is Joker)
            {
                numberOfJokers += 1;
            }
        }

        if (numberOfJokers > 0)
        {
            score = (score * 2) * numberOfJokers;
        }

        return score;
    }
}
