using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class GameSettings : IHashable
    {
        private int _turnLimit;
        private MapType _mapType;
        private int _nbPlayers;
        private String[] _playersNames;
        private IRace[] _playersRaces;
        private int _unitLimit;
        private static GameSettings _INSTANCE;

        private GameSettings()
        {
            throw new System.NotImplementedException();
        }

        ~GameSettings()
        {
            throw new System.NotImplementedException();
        }

        public MapType mapType
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int nbPlayers
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public String[] playersNames
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public IRace[] playersRaces
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int turnLimit
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int unitLimit
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public GameSettings INSTANCE
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public void setFieldsAccordingToMapType()
        {
            throw new System.NotImplementedException();
        }

        public string hash()
        {
            throw new NotImplementedException();
        }
    }
}