using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the Small type map setup.
    /// </summary>
    public class MapStandardSetup : IMapSetup
    {
        /// <summary>
        /// Read and write access to the map field.
        /// </summary>
        public Map map { get; set; }

        /// <summary>
        /// Constructor for the MaptandardSetup class.
        /// </summary>
        /// <param name="map"></param>
        public MapStandardSetup(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Sets up the current object's map field.
        /// </summary>
        public void setupMap()
        {
            map.height = 14;

            // Setup tiles in the c++ //

            map.type = MapType.Standard;
            map.width = 14;
            throw new System.NotImplementedException();
        }
    }
}