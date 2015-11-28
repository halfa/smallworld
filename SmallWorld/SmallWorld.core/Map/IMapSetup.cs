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
        /// This method should be implemented by all sub-classes, and set up the map.
        /// </summary>
        void setupMap();
    }
}