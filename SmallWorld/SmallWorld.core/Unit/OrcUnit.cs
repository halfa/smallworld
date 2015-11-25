using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// The OrcUnit class is a template for Orc units.
    /// </summary>
    [Serializable]
    public class OrcUnit : AUnit
    {
        /// <summary>
        /// Default constructor for the OrcUnit class.
        /// </summary>
        public OrcUnit()
        {
            actionPool = 2;
            attackPt = 5;
            defencePt = 2;
            healthPt = 17;
            position = null;
            range = 1;
        }

        /// <summary>
        /// Constructor using memberwise copy for the OrcUnit class.
        /// </summary>
        /// <param name="orcUnit"></param>
        public OrcUnit(OrcUnit orcUnit)
        {
            actionPool = orcUnit.actionPool;
            attackPt = orcUnit.attackPt;
            defencePt = orcUnit.defencePt;
            healthPt = orcUnit.healthPt;
            position = new Position(orcUnit.position);
            range = orcUnit.range;
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
            if (tile.getType() == TileType.Mountain)
                return 2;
            if (tile.getType() == TileType.Water)
                throw new Exception("Invalid current tile type");
            return 1;
        }

        /// <summary>
        /// Determines the current attack range of the current unit.
        /// This method sould be called to get a "rule wise" answer, whereas the getter of the property provides a "value wise" answer.
        /// </summary>
        /// <param name="currentTile"></param>
        /// <returns></returns>
        public override int getAttackRange(ATile currentTile)
        {
            if (currentTile.getType() == TileType.Mountain)
                return 2;
            if (currentTile.getType() == TileType.Water)
                throw new Exception("Invalid current tile type");
            return 1;
        }

        /// <summary>
        /// Determines the move cost of the current unit, when aiming at the specified tile.
        /// This method does not compute a path cost, just the cost related to the type of the specified tile.
        /// </summary>
        /// <param name="aimedTile"></param>
        /// <returns></returns>
        public override double getMoveCost(ATile aimedTile)
        {
            if (aimedTile.getType() == TileType.Plain)
                return 0.5;
            if (aimedTile.getType() == TileType.Water)
                throw new Exception("Invalid target tile type");
            return 1;
        }
    }
}