using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SmallWorld.Core
{
    [Serializable]
    public class GameData
    {
        private MapData _mapData;
        private GameSettings _gameSettings;
        private GameState _currentState;
        private Stack<GameState> _previousGameStates;
        private PlayerData[] _orderedPlayersData;

        public MapData mapData
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public GameSettings gameSettings
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public GameState currentState
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Stack<GameState> previousGameStates
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public PlayerData[] orderedPlayersData
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static GameData load(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public void save(string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(GameData));
            using (var file = File.OpenWrite(filePath))
            {
                ser.Serialize(file, this);
            }
        }
    }
}