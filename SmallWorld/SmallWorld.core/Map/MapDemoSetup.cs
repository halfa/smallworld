﻿using System.Collections.Generic;
using System.Linq;

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

            // Setup tiles with the c++ "wrapper". //
            Algo algo = new Algo();
            int nbTiles = map.height * map.width; ;
            TileType[] rdmTiles = new TileType[nbTiles];
            rdmTiles = algo.createMap(nbTiles);

            List<ATile> tiles = new List<ATile>(nbTiles+1);
            TileFactory factory = TileFactory.INSTANCE;

            map.tiles = rdmTiles.Select(t => factory.createTile(t)).ToList();
        }
    }
}