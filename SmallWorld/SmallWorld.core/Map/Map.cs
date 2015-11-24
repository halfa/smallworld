using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for game maps.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Read and write acces to the height field.
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Read and write acces to the mapSetup field.
        /// </summary>
        public IMapSetup mapSetup { get; set; }

        /// <summary>
        /// Read and write acces to the tiles field.
        /// </summary>
        public List<ATile> tiles { get; set; }

        /// <summary>
        /// Read and write acces to the type field.
        /// </summary>
        public MapType type { get; set; }

        /// <summary>
        /// Read and write acces to the width field.
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// Constructor for the Map class, with the specified map type.
        /// </summary>
        /// <param name="type"></param>
        public Map(MapType type)
        {
            /*
            This method should create a new IMapSetup and set it as the coresponding attribute according to the MapType.
            */
            switch(type)
            {
                case MapType.Demo:
                    mapSetup = new MapDemoSetup(this);
                    break;
                case MapType.Small:
                    mapSetup = new MapSmallSetup(this);
                    break;
                case MapType.Standard:
                    mapSetup = new MapStandardSetup(this);
                    break;
                default:
                    mapSetup = new MapDemoSetup(this);
                    break;
            }
            setupMap();
        }

        /// <summary>
        /// Sets the map according to its mapSetup field.
        /// </summary>
        public void setupMap()
        {
            mapSetup.setupMap();
        }

        /// <summary>
        /// Creates the serializable data object representing the current map.
        /// </summary>
        /// <returns></returns>
        public MapData toData()
        {
            // This method should handle the memberwise copy of the current mapt's fields before creating a new MapData object with these copies. //
            throw new System.NotImplementedException();
        }
    }
}