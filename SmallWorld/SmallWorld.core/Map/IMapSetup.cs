using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface IMapSetup
    {
        void setupMap(List<ITile> tiles);
    }
}