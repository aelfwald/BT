using System.Text;

namespace BT.CardGame
{
    /// <summary>
    /// The card game service
    /// </summary>
    public class CardGameService(
        IDeckBuilder deckBuilder,
        IInputParser inputParser) : ICardGameService
    {
        private readonly IDeckBuilder _deckBuilder = deckBuilder;
        private readonly IInputParser _inputParser = inputParser;

        public void Play(string requestedCardsInput, IGameOutput output)
        {
            try
            {
                Deck deck = _deckBuilder.BuildDeck();

                if (!_inputParser.TryGetRequestedCards(
                    requestedCardsInput,
                    out IEnumerable<string>? requestedCards,
                    out string errorMessage))
                {
                    output.Print(errorMessage);
                    return;
                }

                Hand hand = new();
                foreach (string requestedCard in requestedCards!)
                {
                    if (!deck.TryDealCard(
                            requestedCard,
                            out Card? card,
                            out errorMessage))
                    {
                        output.Print(errorMessage);
                        return;
                    }

                    hand.AddCard(card!);
                }

                HandScorer scoreHand = new();
                int score = scoreHand.Score(hand);

                output.Print($"Your score is: {score}");
            }

            catch (Exception ex)
            {
                StringBuilder sb = new();
                sb.AppendLine("***********************************************");
                sb.AppendLine($"ERROR PROCESSING SALE: {ex.Message}");
                sb.AppendLine("***********************************************");

                output.Print(sb.ToString());
            }
        }
    }
}

