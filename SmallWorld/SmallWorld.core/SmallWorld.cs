using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class SmallWorld
    {
        private Game _game;
        private ISaveManager _saveManager;
        private ILoadManager _loadManager;

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

        public ISaveManager saveManager
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ILoadManager loadManager
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void loadGame(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public void saveGame()
        {
            throw new System.NotImplementedException();
        }

        public void newGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
