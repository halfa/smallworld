using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface ISavable
    {
        void saveData(string filePath);
        void loadData(string filePath);
    }
}