using Moq;
using Xunit;

namespace BT.CardGame;

public class CardGameServiceTests
{

    [Fact()]
    public void Given_A_Card_Unable_To_Deal_Then_The_Returned_Error_Should_Be_Displayed()
    {

        Mock<IInputParser> parser = new();

        IEnumerable<string> parsedCards = ["QH", "QH"];
        string errorMessage = "";

        parser
            .Setup(m => m.TryGetRequestedCards("QH QH", out parsedCards, out errorMessage))
            .Returns(true);

        var cardGameService = new CardGameService(
            new DeckBuilder(
                new CardProvider()),
                parser.Object
                );

        Mock<IGameOutput> gameOutput = new();

        //Act
        cardGameService.Play("QH QH", gameOutput.Object);

        //Assert
        gameOutput.Verify(m => m.Print("Cards cannot be duplicated"));
    }

     [Fact()]
    public void Given_Valid_Card_Then_Card_Score_Should_Be_Displayed()
    {

        Mock<IInputParser> parser = new();

        IEnumerable<string> parsedCards = ["QH"];
        string errorMessage = "";

        parser
            .Setup(m => m.TryGetRequestedCards("QH", out parsedCards, out errorMessage))
            .Returns(true);

        var cardGameService = new CardGameService(
            new DeckBuilder(
                new CardProvider()),
                parser.Object
                );

        Mock<IGameOutput> gameOutput = new();

        //Act
        cardGameService.Play("QH", gameOutput.Object);

        //Assert
        gameOutput.Verify(m => m.Print("Your score is: 36"));
    }


}
