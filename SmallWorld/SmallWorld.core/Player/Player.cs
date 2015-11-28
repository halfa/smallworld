using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Player
    {
        public Player(String name, Races race)
        {
            this.name = name;
            this.race = race;
            units = new List<AUnit>();
        }

        public Player(Player p)
        {
            name = p.name;
            race = p.race;
            UnitFactory factory = new UnitFactory();
            List<AUnit> tmp = new List<AUnit>(p.units.Count());
            foreach (AUnit unit in p.units)
                tmp.Add(factory.copyUnit(unit));
            units = tmp;
        }

        public Races race { get; set; }

        public List<AUnit> units { get; set; }

        public string name { get; set; }

        public void addNewUnit()
        {
            UnitFactory factory = new UnitFactory();
            units.Add(factory.createUnit(race));
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

        /// <summary>
        /// Returns the hashtable associating the player's units' position to their respective units.
        /// The returned dictionary is not a memberwise copy of the players' attributes, but real references to its fields.
        /// </summary>
        /// <returns></returns>
        public Dictionary<Position, List<AUnit>> getPositionsUnits()
        {
            Dictionary<Position, List<AUnit>> res = new Dictionary<Position, List<AUnit>>();

            foreach(AUnit unit in units)
            {
                if(!res.ContainsKey(unit.position))
                {
                    List<AUnit> list = new List<AUnit>();
                    res.Add(unit.position, list);
                }
            }

            foreach (AUnit unit in units)
                res[unit.position].Add(unit);

            return res;
        }
    }
}
