using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface ISavable
    {
        System.SerializableAttribute toData();
        void loadData(System.SerializableAttribute data);
    }
}