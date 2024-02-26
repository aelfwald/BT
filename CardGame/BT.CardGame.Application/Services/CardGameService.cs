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
                
                if (_inputParser.TryParseCards(
                    requestedCardsInput,
                    out IEnumerable<string>? requestedCards,
                    out string outPutStr))
                {
                    Deck deck = _deckBuilder.BuildDeck();
                    CardGame cardGame = new();
                    cardGame.PlayGame(requestedCards!, deck, out outPutStr);
                }

                output.Print(outPutStr);
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

