using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the serializable game map data.
    /// </summary>
    [Serializable]
    public class MapData
    {
        /// <summary>
        /// Read and write access to the height field.
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Read and write access to the tiles field.
        /// </summary>
        public List<TileType> tiles { get; set; }

        /// <summary>
        /// Read and write access to the type field.
        /// </summary>
        public MapType type { get; set; }

        /// <summary>
        /// Read and write access to the width field.
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// Constructor for the MapData class;
        /// </summary>
        public MapData()
        {
            tiles = new List<TileType>();
        }
    }
}