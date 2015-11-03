using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface ILoadManager
    {
        Game game { get; set; }

        void load(string filePath);
    }
}