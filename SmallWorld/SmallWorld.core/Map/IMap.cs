using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface IMap : ISavable
    {
        List<global::SmallWorld.Core.ITile> tiles { get; set; }
        int width { get; set; }
        int height { get; set; }
    }
}
