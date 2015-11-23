using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for map positions.
    /// </summary>
    [Serializable]
    public class Position
    {
        /// <summary>
        /// Constructor for the Position class.
        /// Creates a position with the specified X and Y coordinates.
        /// </summary>
        /// <param name="px"></param>
        /// <param name="py"></param>
        public Position(int px, int py)
        {
            x = px;
            y = py;
        }

        /// <summary>
        /// Constructor using memberwise copy for the Position class.
        /// </summary>
        /// <param name="position"></param>
        public Position(Position position)
        {
            x = position.x;
            y = position.y;
        }

        /// <summary>
        /// Read and Write access on the X coordinate field.
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// Read and Write access on the X coordinate field.
        /// </summary>
        public int y { get; set; }

        /// <summary>
        /// Determines if the current position is equal to the specified position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool equals(Position position)
        {
            return (x == position.x && y == position.y);
        }
    }
}