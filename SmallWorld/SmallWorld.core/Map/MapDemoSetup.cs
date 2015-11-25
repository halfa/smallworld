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
            map.type = MapType.Demo;
            map.width = 6;

            // Setup tiles with the c++ "wrapper" //
            Algo algo = new Algo();
            int nbTiles = map.height * map.width; ;
            int[] rdmTiles = new int[nbTiles];
            rdmTiles = algo.createMap(nbTiles);

            List<ATile> tiles = new List<ATile>(nbTiles);
            TileFactory factory = TileFactory.INSTANCE;

            for(int i = 0; i < rdmTiles.Count(); i++)
            {
                int val = rdmTiles[i];
                ATile tile;
                switch (val)
                {
                    case 0:
                        tile = factory.createForestTile();
                        break;
                    case 1:
                        tile = factory.createMountainTile();
                        break;
                    case 2:
                        tile = factory.createPlainTile();
                        break;
                    case 3:
                        tile = factory.createWaterTile();
                        break;
                    default:
                        tile = factory.createWaterTile();
                        break;
                }
                tiles[i] = tile;
            }
            map.tiles = tiles;
        }
    }
}