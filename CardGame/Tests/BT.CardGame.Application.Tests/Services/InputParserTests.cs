using FluentAssertions;
using Xunit;

namespace BT.CardGame;

public class InputParserTests
{

    public static IEnumerable<object[]> TestParams
    {
        get
        {
            yield return new object[] { "AS", "", new List<string>() { "AS" }, true };
            yield return new object[] { "AS,AS", "", new List<string>() { "AS", "AS" }, true };
            yield return new object[] { "2S|3D", "Invalid input string", null, false };
            yield return new object[] { "&&", "Invalid input string", null, false };
            yield return new object[] { "JK", "", new List<string>() { "JK" }, true };
            yield return new object[] { "AA", "Card not recognised", null, false };
        }
    }

    [Theory()]
    [MemberData(nameof(TestParams))]
    public void Any_Input_Should_Be_Parsed_Correctly(
        string input,
        string expectedErrorMessage,
        List<string>? expectedCards,
        bool expectedResult)
    {

        //Arrange
        var sut = new InputParser();


        //Act
        bool valid = sut.TryGetRequestedCards(
            input, out IEnumerable<string>? cards, out string errorMessage);

        //Assert
        valid.Should().Be(expectedResult);
        cards.Should().BeEquivalentTo(expectedCards);
        errorMessage.Should().Be(expectedErrorMessage);
    }
}
