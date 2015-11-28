using System;

namespace SmallWorld.Core
{
    /// <summary>
    /// The ElfUnit class is a template for Elven units.
    /// </summary>
    [Serializable]
    public class ElfUnit : AUnit
    {
        /// <summary>
        /// Default constructor for the ElfUnit class.
        /// </summary>
        public ElfUnit()
        {
            actionPool = 2;
            attackPt = 4;
            defencePt = 3;
            healthPt = 12;
            position = null;
            range = 2;
        }

        /// <summary>
        /// Constructor using memberwise copy for the ElfUnit class.
        /// </summary>
        /// <param name="elfUnit"></param>
        public ElfUnit(ElfUnit elfUnit)
        {
            actionPool = elfUnit.actionPool;
            attackPt = elfUnit.attackPt;
            defencePt = elfUnit.defencePt;
            healthPt = elfUnit.healthPt;
            position = new Position(elfUnit.position);
            range = elfUnit.range;
        }

        /// <summary>
        /// Determines if the current unit has the right to cross the specified tile, according to game rules.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override bool canCrossTile(ATile tile)
        {
            if (tile.getType() == TileType.Water)
                return false;
            return true;
        }

        /// <summary>
        /// Determines the number of points the current unit may provide, according to the game rules.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override int countPoints(ATile tile)
        {
            if (tile.getType() == TileType.Forest)
                return 3;
            if (tile.getType() == TileType.Plain)
                return 1;
            if (tile.getType() == TileType.Water)
                throw new Exception("Invalid current tile type");
            return 0;
        }

        /// <summary>
        /// Determines the current attack range of the current unit.
        /// This method sould be called to get a "rule wise" answer, whereas the getter of the property provides a "value wise" answer.
        /// </summary>
        /// <param name="currentTile"></param>
        /// <returns></returns>
        public override int getAttackRange(ATile currentTile)
        {
            if (currentTile.getType() == TileType.Water)
                throw new Exception("Invalid current tile type");
            return range;
        }

        /// <summary>
        /// Determines the move cost of the current unit, when aiming at the specified tile.
        /// This method does not compute a path cost, just the cost related to the type of the specified tile.
        /// </summary>
        /// <param name="aimedTile"></param>
        /// <returns></returns>
        public override double getMoveCost(ATile aimedTile)
        {
            if (aimedTile.getType() == TileType.Mountain)
                return 2;
            if (aimedTile.getType() == TileType.Water)
                throw new Exception("Invalid target tile type");
            return 1;
        }

        /// <summary>
        /// Determines the current unit's race.
        /// </summary>
        /// <returns></returns>
        public override Races getRace()
        {
            return Races.Elf;
        }
    }
}