using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Player
    {
        private string _name;
        private ARace _race;
        private List<AUnit> _units;
        private AUnit _selectedUnit;

        public Player(String name, ARace race)
        {
            throw new System.NotImplementedException();
        }

        public ARace race
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<AUnit> units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string name
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void addNewUnit()
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

        public PlayerData toData()
        {
            throw new System.NotImplementedException();
        }
    }
}
