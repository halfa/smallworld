﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface ISaveManager
    {
        ISaveFile saveFile { get; set; }
        void save(string filePath);
    }
}