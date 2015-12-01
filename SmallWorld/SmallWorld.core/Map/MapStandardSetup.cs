using System.Collections.Generic;
using System.Linq;

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
            map.type = MapType.Standard;
            map.width = 14;

            // Setup tiles with the c++ "wrapper" //
            Algo algo = new Algo();
            int nbTiles = map.height * map.width; ;
            TileType[] rdmTiles = new TileType[nbTiles];
            rdmTiles = algo.createMap(nbTiles);

            List<ATile> tiles = new List<ATile>(nbTiles);
            TileFactory factory = TileFactory.INSTANCE;

            for (int i = 0; i < rdmTiles.Count(); i++)
            {
                TileType val = rdmTiles[i];
                ATile tile = factory.createTile(val);
                tiles[i] = tile;
            }
            map.tiles = tiles;
        }
    }
}