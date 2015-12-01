using System;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for water tiles.
    /// </summary>
    [Serializable]
    public class Water : ATile
    {
        /// <summary>
        /// Default constructor for the Water class.
        /// </summary>
        public Water()
        {
        }

        /// <summary>
        /// Provide the TileType related to Water tiles.
        /// </summary>
        /// <returns></returns>
        public override TileType getType()
        {
            return TileType.Water;
        }
    }
}
