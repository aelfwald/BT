using FluentAssertions;
using Xunit;

namespace BT.CardGame;

public class DeckTests
{
    [Fact()]
    public void When_Joker_Is_Requested_Then_Correct_Card_Is_Returned()
    {
        //Arrange
        Deck deck = new();

        deck.Add(new Joker());

        //Act
        bool result = deck.TryDealCard("JK", out Card? card, out _);

        //Assert
        result.Should().BeTrue();
        card.Should().BeOfType<Joker>();
    }

    [Fact()]
    public void When_Valid_Card_Is_Requested_Then_Card_Is_Returned()
    {
        //Arrange
        Deck deck = new();
        deck.Add(new StandardCard(rank: "A", suit: "S"));

        //Act
        bool result = deck.TryDealCard("AS", out Card? card, out string errorMessage);

        //Assert
        result.Should().BeTrue();
        card.Should().BeOfType<StandardCard>();
        errorMessage.Should().Be("");
    }
}
