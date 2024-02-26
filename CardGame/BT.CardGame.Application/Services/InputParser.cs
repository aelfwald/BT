
using System.Text.RegularExpressions;

namespace BT.CardGame;

/// <summary>
/// The input parser
/// </summary>
public class InputParser : IInputParser
{
    public bool TryParseCards(
        string input, 
        out IEnumerable<string>? cardNames,
        out string errorMessage)
    {
        errorMessage = "";
        cardNames = null;
        Regex validateInputString = new ("^([0-9A-Z][A-Z])(,[0-9A-Z][A-Z])*$");

        input = input.Trim().ToUpper(); //Sanitise input

        if (!validateInputString.IsMatch(input))
        {
            errorMessage = "Invalid input string";
            return false;
        }

        string[] cardNamesTemp = input.Split(',');

        Regex validateCard = new("[2-9TJQKA][CDHS]|JK");

        foreach (string cardName in cardNamesTemp) 
        {
            if (!validateCard.IsMatch(cardName))
            {
                errorMessage = "Card not recognised";
                return false;
            }
        }
        cardNames = cardNamesTemp;

        return true;
    }
}
