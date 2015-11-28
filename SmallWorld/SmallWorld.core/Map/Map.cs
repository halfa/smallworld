using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Constructor for the Map class using the specified mapData to recreate the map.
        /// </summary>
        /// <param name="mapData"></param>
        public Map(MapData mapData)
        {
            height = mapData.height;
            type = mapData.type;
            width = mapData.width;

            List<ATile> t = new List<ATile>(mapData.tiles.Count());
            TileFactory factory = TileFactory.INSTANCE;

            for(int i = 0; i < mapData.tiles.Count(); i++)
                t[i] = factory.createTile(mapData.tiles[i]);

            // The mapSetup field will never be used, because the map has been set up already. //
            // *Eventually*, this field could be removed, but keeping the stategy DP intact. //
            mapSetup = null;
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
            // This method should handle the memberwise copy of the current map's fields before creating a new MapData object with these copies. //
            MapData data = new MapData();
            data.height = height;
            data.width = width;
            data.type = type;

            List<TileType> copiedTiles = new List<TileType>(tiles.Count());
            for(int i = 0; i < tiles.Count(); i++)
                copiedTiles[i] = tiles[i].getType();

            data.tiles = copiedTiles;

            return data;
        }

        /// <summary>
        /// Determines a valid random starting position for the specified race of player.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public Position getRandomStartPos(Races race)
        {
            Random rd = new Random();

            int x = rd.Next() % width;
            int y = rd.Next() % height;

            if (race == Races.Human)
                return new Position(x, y);
            else
            {
                while (tiles[x + y*width].getType() == TileType.Water)
                {
                        x = rd.Next() % width;
                        y = rd.Next() % height;
                }
                return new Position(x, y);
            }
        }

        /// <summary>
        /// Returns the tile at the specified position.
        /// If the specified position is invalid, throws an exception.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public ATile getTileAtPos(Position p)
        {
            if (p.x < 0 || p.x >= width || p.y < 0 || p.y >= height)
                throw new Exception("Invalid coordinates.");
            else
            {
                return tiles[p.x + width * p.y];
            }
        }
    }
}