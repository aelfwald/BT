using BT.CardGame;
using FluentAssertions;
using Xunit;

namespace BT.CardGames;

public class CardProviderTests
{
    [Fact]
    public void Ensure_Card_Provider_Returns_Full_Pack_Of_Cards()
    {
        //Arrange
        CardProvider provider = new();

        IEnumerable<Card> cards = provider.GetCards();  

        cards.Count().Should().Be(54);
        cards.OfType<StandardCard>().Count().Should().Be(52);
        cards.OfType<StandardCard>().Where( s => s.Suit == "C").Count().Should().Be(13);
        cards.OfType<StandardCard>().Where(s => s.Suit == "D").Count().Should().Be(13);
        cards.OfType<StandardCard>().Where(s => s.Suit == "H").Count().Should().Be(13);
        cards.OfType<StandardCard>().Where(s => s.Suit == "S").Count().Should().Be(13);
        cards.OfType<Joker>().Count().Should().Be(2);
    }
}
