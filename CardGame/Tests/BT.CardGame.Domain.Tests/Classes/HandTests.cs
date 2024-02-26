using FluentAssertions;
using Xunit;

namespace BT.CardGame;

public class HandTests
{

    [Fact()]
    public void Ensure_A_Card_Can_Be_Added_To_A_Hand()
    {
        //Arrange
        Hand hand = new ();
        StandardCard card = new (rank: "2", suit: "C");

        //Act
        hand.AddCard(card);

        //Assert
        hand.Cards.Should().Contain(card);
    }


}
