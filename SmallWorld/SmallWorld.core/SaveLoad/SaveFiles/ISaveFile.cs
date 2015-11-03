using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface ISaveFile
    {
        String filePath { get; set; }
        string data { get; set; }

        void saveToDisk();
    }
}