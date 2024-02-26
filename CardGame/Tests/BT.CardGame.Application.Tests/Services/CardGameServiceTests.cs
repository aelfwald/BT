using Moq;
using Xunit;

namespace BT.CardGame;

public class CardGameServiceTests
{

    [Fact()]
    public void When_Unable_To_Parse_Input_An_Appropriate_Output_Is_Displayed()
    {

        Mock<IInputParser> parser = new();

        IEnumerable<string>? parsedCards = ["QH", "QH"];
        string errorMessage = "unable to parse output";

        parser
            .Setup(m => m.TryParseCards("notvalid", out parsedCards, out errorMessage))
            .Returns(false);


        var cardGameService = new CardGameService(
            new DeckBuilder(
                new CardProvider()),
                parser.Object
                );

        Mock<IGameOutput> gameOutput = new();

        //Act
        cardGameService.Play("notvalid", gameOutput.Object);

        //Assert
        gameOutput.Verify(m => m.Print(errorMessage));
    }

     [Fact()]
    public void Given_Valid_Card_Then_Card_Score_Should_Be_Displayed()
    {

        Mock<IInputParser> parser = new();
        Mock<ICardProvider> cardProvider = new();
        cardProvider.Setup(m => m.GetCards()).Returns(
            [
                new StandardCard("Q", "H")
            ]);

        IEnumerable<string>? parsedCards = ["QH"];
        string errorMessage = "";

        parser
            .Setup(m => m.TryParseCards("QH", out parsedCards, out errorMessage))
            .Returns(true);

        var cardGameService = new CardGameService(
                new DeckBuilder(
                    cardProvider.Object),
                parser.Object);

        Mock<IGameOutput> gameOutput = new();

        //Act
        cardGameService.Play("QH", gameOutput.Object);

        //Assert
        gameOutput.Verify(m => m.Print("Your score is: 36"));
    }
}
