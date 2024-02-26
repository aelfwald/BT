using FluentAssertions;
using Xunit;

namespace BT.CardGame;

public class StandardCardTests
{

    [Fact()]
    public void Ensure_A_Standard_Cards_Name_Is_Correct()
    {
        //Arrange
        //Act
        StandardCard card = new (rank: "2", suit: "C");

        //Assert
        card.Name.Should().Be("2C");
    }


}
