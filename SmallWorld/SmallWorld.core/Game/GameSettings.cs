using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    [Serializable]
    public class GameSettings
    {
        public GameSettings()
        {
            playersNames = new List<string>();
            playersRaces = new List<Races>();
        }

        public MapType mapType { get; set; }

        public int nbPlayers { get; set; }

        public List<string> playersNames { get; set; }

        public List<Races> playersRaces { get; set; }

        public int turnLimit { get; set; }

        public int unitLimit { get; set; }

        public void setFieldsAccordingToMapType()
        {
            throw new System.NotImplementedException();
        }
    }
}