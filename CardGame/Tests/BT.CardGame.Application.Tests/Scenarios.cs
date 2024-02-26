using Moq;
using System.ComponentModel;
using Xunit;

namespace BT.CardGame.Application.Tests
{
    public class Scenarios
    {

        [Theory()]
        [InlineData("2C", 2)]
        [InlineData("2D", 4)]
        [InlineData("2H", 6)]
        [InlineData("2S", 8)]
        [InlineData("TC", 10)]
        [InlineData("JC", 11)]
        [InlineData("QC", 12)]
        [InlineData("KC", 13)]
        [InlineData("AC", 14)]
        [InlineData("3C,4C", 7)]
        [InlineData("TC,TD,TH,TS", 100)]
        public void Given_When_I_Enter_Card_Then_The_Correct_Score_Should_Be_Displayed(
            string input,
            int score)
        {
              var cardGameService = new CardGameService(
                new DeckBuilder(
                    new CardProvider()),
                new InputParser());

            Mock<IGameOutput> gameOutput = new();

            //Act
            cardGameService.Play(input, gameOutput.Object);

            //Assert
            gameOutput.Verify(m => m.Print($"Your score is: {score}"));
        }

        [Theory()]
        [InlineData( "JK", 0)]
        [InlineData("JK,JK", 0)]
        [InlineData("2C,JK", 4)]
        [InlineData("JK,2C,JK", 8)]
        [InlineData("TC,TD,JK,TH,TS", 200)]
        [InlineData("TC,TD,JK,TH,TS,JK",400)]
        public void Given_When_I_Enter_A_List_Of_Cards_Containing_One_Or_More_Jokers_Then_The_Correct_Score_Should_Be_Displayed(
                string input,
                int score)
        {
            var cardGameService = new CardGameService(
              new DeckBuilder(
                  new CardProvider()),
              new InputParser());

            Mock<IGameOutput> gameOutput = new();

            //Act
            cardGameService.Play(input, gameOutput.Object);

            //Assert
            gameOutput.Verify(m => m.Print($"Your score is: {score}"));
        }


        [Theory()]
        [InlineData("1S", "Card not recognised")]
        [InlineData("2B", "Card not recognised")]
        [InlineData("2S,1S", "Card not recognised")]
        [InlineData("3H,3H", "Cards cannot be duplicated")]
        [InlineData("4D,5D,4D", "Cards cannot be duplicated")]
        [InlineData("JK,JK,JK", "A hand cannot contain more than two Jokers")]
        [InlineData("2S|3D", "Invalid input string")]

        public void Given_When_I_Enter_A_List_Of_Cards_Thats_Invalid_Then_A_Message_Should_Be_Displayed(
                string input,
                string errorMessage)
        {
            var cardGameService = new CardGameService(
              new DeckBuilder(
                  new CardProvider()),
              new InputParser());

            Mock<IGameOutput> gameOutput = new();

            //Act
            cardGameService.Play(input, gameOutput.Object);

            //Assert
            gameOutput.Verify(m => m.Print(errorMessage));
        }
    }
}
