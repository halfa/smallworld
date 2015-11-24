using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the Demo type map setup.
    /// </summary>
    public class MapDemoSetup : IMapSetup
    {
        /// <summary>
        /// Read and write access to the map field.
        /// </summary>
        public Map map { get; set; }

        /// <summary>
        /// Constructor for the MapDemoSetup class.
        /// </summary>
        /// <param name="map"></param>
        public MapDemoSetup(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Sets up the current object's map field.
        /// </summary>
        public void setupMap()
        {
            map.height = 6;

            // Setup tiles in the c++ //

            map.type = MapType.Demo;
            map.width = 6;
            throw new System.NotImplementedException();
        }
    }
}