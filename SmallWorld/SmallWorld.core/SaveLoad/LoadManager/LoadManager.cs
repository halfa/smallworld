﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class LoadManager : ILoadManager
    {
        private Game _game;
        private LoadManager _INSTANCE;

        /*
        public static GameData load(string filePath)
        {
            throw new System.NotImplementedException();
        }
        */

        private LoadManager()
        {
            throw new System.NotImplementedException();
        }

        public Game game
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public LoadManager INSTANCE
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public void loadGame(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}
 