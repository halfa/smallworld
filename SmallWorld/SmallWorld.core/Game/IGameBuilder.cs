namespace SmallWorld.Core
{
    /// <summary>
    /// This interface is a template for all game builders.
    /// </summary>
    public interface IGameBuilder
    {
        /// <summary>
        /// Read and write access to the game settings used to build the game.
        /// </summary>
        GameSettings gameSettings { get; set; }

        /// <summary>
        /// Creates a game according to the settings, and returns it.
        /// </summary>
        /// <returns></returns>
        Game build();
    }
}