using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class LoadManager : ILoadManager
    {
        private static LoadManager _INSTANCE = new LoadManager();

        private LoadManager()
        {
            game = null;
        }

        public Game game { get; set; }

        public static LoadManager INSTANCE { get; }

        public void loadGame(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}
 