using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Player
    {
        private string _name;
        private global::SmallWorld.Core.ARace _race;
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

        public System.Collections.Generic.List<global::SmallWorld.Core.AUnit> units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public String name
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
