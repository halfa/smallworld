using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// Manage settings provided by the UI
    /// </summary>
    [Serializable]
    public class GameSettings
    {
        public GameSettings()
        {
            // nothing defined by default
        }

        public MapType mapType { get; set; }
        public int nbPlayers { get; set; }
        public String[] playersNames { get; set; } // set by UI
        public ARace[] playersRaces { get; set; } // set by UI
        public int turnLimit { get; set; }
        public int unitLimit { get; set; }

        public void setFieldsAccordingToMapType()
        {
            switch (mapType) {
                case MapType.Demo:
                    nbPlayers = 2;
                    turnLimit = 5;
                    unitLimit = 4;
                    break;
                case MapType.Small:
                    nbPlayers = 2;
                    turnLimit = 10;
                    unitLimit = 6;
                    break;
                case MapType.Standard:
                    nbPlayers = 2;
                    turnLimit = 30;
                    unitLimit = 8;
                    break;
            }
        }
    }
}