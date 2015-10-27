using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Player
    {
        private string _name;
        private int _score;
        private Undo _undo;
        private Race _race;
        private int _units;

        public Player(String name)
        {
            throw new System.NotImplementedException();
        }

        ~Player()
        {
            throw new System.NotImplementedException();
        }

        public Race race
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<SmallWorld.Core.Unit> units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Undo undo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
