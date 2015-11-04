using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Player
    {
        private string _name;
        private global::SmallWorld.Core.IRace _race;
        private List<AUnit> _units;
        private Game _game;
        private AUnit _selectedUnit;

        public Player(String name, IRace race)
        {
            throw new System.NotImplementedException();
        }

        public Player(Player player)
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

        public AUnit selectedUnit
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

        public AUnit selectUnitAtPosition(Position position)
        {
            throw new System.NotImplementedException();
        }

        public void moveSelectedUnitTo(Position position)
        {
            /*
            This method should call the attack xor the move method of the selected unit.
            Care about friendly fire.
            */
            throw new System.NotImplementedException();
        }

        public bool isSelectedUnitMovableTo(Position position)
        {
            /*  
            Checks the range compared to the remaining move points. 
            Checks if the tile at the new position is walkable for the selected unit.
            */
            throw new System.NotImplementedException();
        }

        public PlayerData toData()
        {
            throw new System.NotImplementedException();
        }
    }
}
