using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public class ElfUnit : AUnit
    {
        public ElfUnit()
        {
            actionPool = 2;
            attackPt = 4;
            defencePt = 3;
            healthPt = 12;
            position = null;
            range = 2;
        }

        public ElfUnit(ElfUnit elfUnit)
        {
            actionPool = elfUnit.actionPool;
            attackPt = elfUnit.attackPt;
            defencePt = elfUnit.defencePt;
            healthPt = elfUnit.healthPt;
            position = new Position(elfUnit.position);
            range = elfUnit.range;
        }

        public override bool canCrossTile(ATile tile)
        {
            if (tile.GetType().Equals(typeof(Water)))
                return false;
            return true;
        }

        public override int countPoints(ATile tile)
        {
            if (tile.GetType().Equals(typeof(Forest)))
                return 3;
            if (tile.GetType().Equals(typeof(Plain)))
                return 1;
            return 0;
        }

        public override int getAttackRange(ATile currentTile)
        {
            return range;
        }

        public override double getMoveCost(ATile aimedTile)
        {
            if (aimedTile.GetType().Equals(typeof(Mountain)))
                return 2;
            if (aimedTile.GetType().Equals(typeof(Water)))
                throw new Exception("Invalid target tile type");
            return 1;
        }
    }
}