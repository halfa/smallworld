using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public class HumanUnit : AUnit
    {
        public HumanUnit()
        {
            actionPool = 2;
            attackPt = 6;
            defencePt = 3;
            healthPt = 15;
            position = null;
            range = 1;
        }

        public HumanUnit(HumanUnit humanUnit)
        {
            actionPool = humanUnit.actionPool;
            attackPt = humanUnit.attackPt;
            defencePt = humanUnit.defencePt;
            healthPt = humanUnit.healthPt;
            position = new Position(humanUnit.position);
            range = humanUnit.range;
        }

        public override bool canCrossTile(ATile tile)
        {
            return true;
        }

        public override int countPoints(ATile tile)
        {
            if (tile.GetType().Equals(typeof(Plain)))
                return 2;
            if (tile.GetType().Equals(typeof(Water)))
                return 0;
            return 1;
        }

        public override int getAttackRange(ATile currentTile)
        {
            return range;
        }

        public override double getMoveCost(ATile aimedTile)
        {
            return 1;
        }
    }
}
