using System;

namespace SmallWorld.Core
{
    /// <summary>
    /// The HumanUnit class is a template for Human units.
    /// </summary>
    [Serializable]
    public class HumanUnit : AUnit
    {
        /// <summary>
        /// Default constructor for the HumanUnit class.
        /// </summary>
        public HumanUnit()
        {
            actionPool = 2;
            attackPt = 6;
            defencePt = 3;
            healthPt = 15;
            position = new Position(0, 0);
            range = 1;
        }

        /// <summary>
        /// Constructor using memberwise copy for the HumanUnit class.
        /// </summary>
        /// <param name="humanUnit"></param>
        public HumanUnit(HumanUnit humanUnit)
        {
            actionPool = humanUnit.actionPool;
            attackPt = humanUnit.attackPt;
            defencePt = humanUnit.defencePt;
            healthPt = humanUnit.healthPt;
            position = new Position(humanUnit.position);
            range = humanUnit.range;
        }

        /// <summary>
        /// Determines if the current unit has the right to cross the specified tile, according to game rules.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override bool canCrossTile(ATile tile)
        {
            return true;
        }

        /// <summary>
        /// Determines the number of points the current unit may provide, according to the game rules.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override int countPoints(ATile tile)
        {
            if (tile.getType() == TileType.Plain)
                return 2;
            if (tile.getType() == TileType.Water)
                return 0;
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
            return 1;
        }

        /// <summary>
        /// Determines the current unit's race.
        /// </summary>
        /// <returns></returns>
        public override Races getRace()
        {
            return Races.Human;
        }
    }
}
