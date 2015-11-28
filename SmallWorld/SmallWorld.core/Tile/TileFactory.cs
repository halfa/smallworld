namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for a flyweight tile factory.
    /// It also uses the Singleton design pattern.
    /// </summary>
    public class TileFactory
    {
        /// <summary>
        /// The unique private plain tile.
        /// </summary>
        private Plain _plainTile;

        /// <summary>
        /// The unique private water tile.
        /// </summary>
        private Water _waterTile;

        /// <summary>
        /// The unique private forest tile.
        /// </summary>
        private Forest _forestTile;

        /// <summary>
        /// The unique private mountain tile.
        /// </summary>
        private Mountain _mountainTIle;

        /// <summary>
        /// The singleton for the TileFactory class.
        /// </summary>
        private static TileFactory _INSTANCE = new TileFactory();

        /// <summary>
        /// Private constructor for the TileFactory class.
        /// Initializes the private flyweight tiles.
        /// </summary>
        private TileFactory()
        {
            _plainTile = new Plain();
            _waterTile = new Water();
            _forestTile = new Forest();
            _mountainTIle = new Mountain();
        }

        /// <summary>
        /// Read-only access to the unique instance of tile factory.
        /// </summary>
        public static TileFactory INSTANCE
        {
            get
            {
                return _INSTANCE;
            }
        }

        /// <summary>
        /// Returns the unique private forest tile.
        /// </summary>
        /// <returns></returns>
        public Forest createForestTile()
        {
            return _forestTile;
        }

        /// <summary>
        /// Returns the unique private mountain tile.
        /// </summary>
        /// <returns></returns>
        public Mountain createMountainTile()
        {
            return _mountainTIle;
        }

        /// <summary>
        /// Returns the unique private plain tile.
        /// </summary>
        /// <returns></returns>
        public Plain createPlainTile()
        {
            return _plainTile;
        }

        /// <summary>
        /// Returns the unique private water tile.
        /// </summary>
        /// <returns></returns>
        public Water createWaterTile()
        {
            return _waterTile;
        }

        /// <summary>
        /// Returns the unique private tile of the specified type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ATile createTile(TileType type)
        {
            ATile tile;
            switch (type)
            {
                case TileType.Forest:
                    tile = createForestTile();
                    break;
                case TileType.Mountain:
                    tile = createMountainTile();
                    break;
                case TileType.Plain:
                    tile = createPlainTile();
                    break;
                case TileType.Water:
                    tile = createWaterTile();
                    break;
                default:
                    tile = createWaterTile();
                    break;
            }
            return tile;
        }
    }
}
