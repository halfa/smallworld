﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface ISaveFile
    {
        void loadGame(ISaveFile file);
        void saveGame();
    }
}