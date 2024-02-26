namespace BT.CardGame;

/// <summary>
/// Defines the card game service
/// </summary>
public interface ICardGameService
{
    /// <summary>
    /// Plays the game.
    /// </summary>
    /// <param name="cards">The cards requested in a comma separated string</param>
    /// <param name="output">A service that provides output to the ui</param>
    void Play(string cards, IGameOutput output);
}
