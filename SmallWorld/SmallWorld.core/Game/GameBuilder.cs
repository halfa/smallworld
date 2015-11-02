using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class GameBuilder : IGameBuilder
    {
        private GameSettings _settings;

        public GameBuilder()
        {
            throw new System.NotImplementedException();
        }

        ~GameBuilder()
        {
            throw new System.NotImplementedException();
        }

        public Game build()
        {
            throw new System.NotImplementedException();
        }

        protected void buildMap()
        {
            throw new System.NotImplementedException();
        }

        protected void buildPlayers()
        {
            throw new System.NotImplementedException();
        }

        protected void buildUnits(Player player)
        {
            throw new System.NotImplementedException();
        }

        public SmallWorld.Core.IGameBuilder settings(GameSettings settings)
        {
            throw new System.NotImplementedException();
        }
    }
}