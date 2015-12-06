namespace SmallWorld.Core
{
    /// <summary>
    /// This interface is a template for Map Setups.
    /// </summary>
    public interface IMapSetup
    {
        /// <summary>
        /// Reand and write access to the map field (the map to set up).
        /// </summary>
        Map map { get; set; }

        /// <summary>
        /// Sets the map according to the game rules (generate the list of tiles, and the map attributes in general).
        /// </summary>
        void setupMap();
    }
}