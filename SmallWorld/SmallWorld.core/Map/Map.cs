﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface Map
    {
        List<SmallWorld.Core.Tile> tiles { get; set; }
        int width { get; set; }
        int height { get; set; }
    }
}