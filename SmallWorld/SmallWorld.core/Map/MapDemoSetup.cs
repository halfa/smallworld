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

            Algo algo = new Algo();
            int nbTiles = 36;
            int[] rdmTiles = new int[nbTiles];
            rdmTiles = algo.createMap(nbTiles);

            //Wrapper wrapper;
            // Setup tiles in the c++ //
            // For now, setting uit up here //
            List<ATile> tiles = new List<ATile>(36);
            List<int> simplifiedTiles = new List<int>(36);
            TileFactory factory = TileFactory.INSTANCE;

            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 9; j++)
                    simplifiedTiles[i * 4 + j] = i;

            Random rdm = new Random();
            for(int i = 0; i < simplifiedTiles.Count(); i++)
            {
                int rd = rdm.Next(36);
                int tmp = simplifiedTiles[i];
                simplifiedTiles[i] = simplifiedTiles[rd];
                simplifiedTiles[rd] = tmp;
            }

            for(int i = 0; i < simplifiedTiles.Count(); i++)
            {
                int val = simplifiedTiles[i];
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

            map.type = MapType.Demo;
            map.width = 6;
            throw new System.NotImplementedException();
        }
    }
}