using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Player
    {
        private string _name;
        private SmallWorld.Core.IRace _race;
        private List<AUnit> _units;
        private Game _game;

        public Player(String name, IRace race)
        {
            throw new System.NotImplementedException();
        }

        public Player(Player player)
        {
            throw new System.NotImplementedException();
        }

        ~Player()
        {
            throw new System.NotImplementedException();
        }

        public IRace race
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public System.Collections.Generic.List<SmallWorld.Core.AUnit> units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
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

        public void undo()
        {
            throw new System.NotImplementedException();
        }

        public void addUnit(AUnit unit)
        {
            throw new System.NotImplementedException();
        }

        public void removeUnit(AUnit unit)
        {
            throw new System.NotImplementedException();
        }

        public int countPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}
