using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the Small type map setup.
    /// </summary>
    public class MapSmallSetup : IMapSetup
    {
        /// <summary>
        /// Read and write access to the map field.
        /// </summary>
        public Map map { get; set; }

        /// <summary>
        /// Constructor for the MapSmallSetup class.
        /// </summary>
        /// <param name="map"></param>
        public MapSmallSetup(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Sets up the current object's map field.
        /// </summary>
        public void setupMap()
        {
            map.height = 10;

            // Setup tiles in the c++ //

            map.type = MapType.Small;
            map.width = 10;
            throw new System.NotImplementedException();
        }
    }
}