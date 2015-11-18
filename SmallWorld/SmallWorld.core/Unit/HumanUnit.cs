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
            throw new System.NotImplementedException();
        }

        public HumanUnit(HumanUnit humanUnit)
        {
            throw new System.NotImplementedException();
        }

        public override bool canCrossTile(ATile tile)
        {
            throw new NotImplementedException();
        }

        public override int countPoints()
        {
            throw new NotImplementedException();
        }
    }
}
