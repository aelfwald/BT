namespace BT.CardGame;

/// <summary>
/// Defines a services used to output to the ui
/// </summary>
public interface IGameOutput
{
    /// <summary>
    /// Prints to the UI
    /// </summary>
    /// <param name="output"></param>
    void Print(string output);
}
