using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public List<ATile> tiles { get; set; }

        /// <summary>
        /// Read and write access to the type field.
        /// </summary>
        public MapType type { get; set; }

        /// <summary>
        /// Read and write access to the width field.
        /// </summary>
        public int width { get; set; }
    }
}