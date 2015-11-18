using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public class OrcUnit : AUnit
    {
        public OrcUnit()
        {
            actionPool = 2;
            attackPt = 5;
            defencePt = 2;
            healthPt = 17;
            position = null;
            range = 1;
        }

        public OrcUnit(OrcUnit orcUnit)
        {
            actionPool = orcUnit.actionPool;
            attackPt = orcUnit.attackPt;
            defencePt = orcUnit.defencePt;
            healthPt = orcUnit.healthPt;
            position = new Position(orcUnit.position);
            range = orcUnit.range;
        }

        public override bool canCrossTile(ATile tile)
        {
            if (tile.GetType().Equals(typeof(Water)))
                return false;
            return true;
        }

        public override int countPoints(ATile tile)
        {
            if (tile.GetType().Equals(typeof(Mountain)))
                return 2;
            if (tile.GetType().Equals(typeof(Water)))
                return 0;
            return 1;
        }

        public override int getAttackRange(ATile currentTile)
        {
            if (currentTile.GetType().Equals(typeof(Mountain)))
                return 2;
            return 1;
        }

        public override double getMoveCost(ATile aimedTile)
        {
            if (aimedTile.GetType().Equals(typeof(Plain)))
                return 0.5;
            if (aimedTile.GetType().Equals(typeof(Water)))
                throw new Exception("Invalid target tile type");
            return 1;
        }
    }
}