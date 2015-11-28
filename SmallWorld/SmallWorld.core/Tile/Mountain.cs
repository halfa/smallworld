using System;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for mountain tiles.
    /// </summary>
    [Serializable]
    public class Mountain : ATile
    {
        /// <summary>
        /// Default constructor for the Mountain class.
        /// </summary>
        public Mountain()
        {
        }

        /// <summary>
        /// Provide the TileType related to Mountain tiles.
        /// </summary>
        /// <returns></returns>
        public override TileType getType()
        {
            return TileType.Mountain;
        }
    }
}
