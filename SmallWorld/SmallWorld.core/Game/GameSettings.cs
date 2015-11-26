using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public class GameSettings
    {
        public GameSettings()
        {
            throw new System.NotImplementedException();
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