namespace BT.CardGame
{
    /// <summary>
    /// The card game to be played
    /// </summary>
    public class CardGame
    {
        /// <summary>
        /// Plays the game with the cards selected by the player
        /// </summary>
        /// <param name="cards">The card selected</param>
        /// <param name="deck">The deck of cards</param>
        /// <param name="output">Output from the card game</param>
        public void PlayGame(
            IEnumerable<string> cards, 
            Deck deck,
            out string output)
        {
            Hand hand = new();
            output = "";
            foreach (string requestedCard in cards!)
            {
                if (!deck.TryDealCard(
                        requestedCard,
                        out Card? card,
                        out output))
                {
                    return;
                }

                hand.AddCard(card!);
            }

            HandScorer scoreHand = new();
            int score = scoreHand.Score(hand);
            output = $"Your score is: {score}";
        }
    }
}
