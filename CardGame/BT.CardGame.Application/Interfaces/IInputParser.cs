namespace BT.CardGame;

/// <summary>
/// Defines a service that parsers the input to the card game.
/// </summary>
public interface IInputParser
{
    /// <summary>
    /// Parses the input and returns the requested cards.
    /// </summary>
    /// <param name="input">The requested cards</param>
    /// <param name="cards">A parsed list of requested cards</param>
    /// <param name="errorMessage">An error message if the parse failed</param>
    /// <returns>True if input parsed successfullyl ,otherwise false</returns>
    bool TryParseCards(string input, out IEnumerable<string>? cards, out string errorMessage);
}
