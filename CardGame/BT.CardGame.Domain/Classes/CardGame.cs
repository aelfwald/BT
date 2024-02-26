namespace BT.CardGame
{
    public class CardGame
    {
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
