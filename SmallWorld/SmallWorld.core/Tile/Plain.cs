﻿using System;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for plain tiles.
    /// </summary>
    [Serializable]
    public class Plain : ATile
    {
        /// <summary>
        /// Default constructor for the Plain class.
        /// </summary>
        public Plain()
        {
        }

        /// <summary>
        /// Provides the TileType related to Plain tiles.
        /// </summary>
        /// <returns></returns>
        public override TileType getType()
        {
            return TileType.Plain;
        }
    }
}
