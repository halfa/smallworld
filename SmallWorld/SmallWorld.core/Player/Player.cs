using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for game players.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Constructor for the Player class.
        /// Creates a player with the specified name and race.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="race"></param>
        public Player(String name, Races race)
        {
            this.name = name;
            this.race = race;
            units = new List<AUnit>();
            points = 0;
        }

        /// <summary>
        /// Default constructor for the Player class.
        /// </summary>
        public Player() { }

        /// <summary>
        /// Memberwise constructor for the Player class.
        /// </summary>
        /// <param name="p"></param>
        public Player(Player p)
        {
            name = p.name;
            race = p.race;
            points = p.points;
            UnitFactory factory = new UnitFactory();
            List<AUnit> tmp = new List<AUnit>(p.units.Count());
            foreach (AUnit unit in p.units)
                tmp.Add(factory.copyUnit(unit));
            units = tmp;
        }

        /// <summary>
        /// Constructor for the Player class using the specified playerData to recreate the player.
        /// </summary>
        /// <param name="mapData"></param>
        public Player(PlayerData data)
        {
            points = data.points;
            race = data.race;
            name = data.name;
            units = data.units;
        }

        /// <summary>
        /// Read and write access to the current player's name field.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Read and write access to the current player's victory points.
        /// </summary>
        public int points { get; set; }

        /// <summary>
        /// Read and write access to the current player's race field.
        /// </summary>
        public Races race { get; set; }

        /// <summary>
        /// Read and write access to the current player's units field.
        /// </summary>
        public List<AUnit> units { get; set; }

        /// <summary>
        /// Adds a new unit to the current player, according to his race.
        /// </summary>
        public void addNewUnit()
        {
            UnitFactory factory = new UnitFactory();
            units.Add(factory.createUnit(race));
        }

        /// <summary>
        /// Counts the number of points the player would get if the turn ended now.
        /// </summary>
        /// <returns></returns>
        public int countPoints(Map map)
        {
            SerializableDictionary<Position, List<AUnit>> dic = getPositionsUnits();
            int res = 0;
            foreach (Position p in dic.Keys)
                res += dic[p][0].countPoints(map.getTileAtPos(p));

            return res;
        }

        /// <summary>
        /// Returns the serializable dictionary associating the player's units' position to their respective units.
        /// The returned dictionary is not a memberwise copy of the players' attributes, but real references to its fields.
        /// </summary>
        /// <returns></returns>
        public SerializableDictionary<Position, List<AUnit>> getPositionsUnits()
        {
            SerializableDictionary<Position, List<AUnit>> res = new SerializableDictionary<Position, List<AUnit>>();

            foreach (AUnit unit in units)
            {
                if (!res.ContainsKey(unit.position))
                {
                    List<AUnit> list = new List<AUnit>();
                    res.Add(unit.position, list);
                }
            }

            foreach (AUnit unit in units)
                res[unit.position].Add(unit);

            return res;
        }

        /// <summary>
        /// Determines if the specified unit belongs to the current player.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool hasUnit(AUnit unit)
        {
            return units.Contains(unit);
        }

        /// <summary>
        /// Determines if the specified player can still play the game, ie is not dead.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool isAlive(Player p)
        {
            return !Player.isDead(p);
        }

        /// <summary>
        /// Determines if the specified player can't play anymore, due to lack of alive units.
        /// </summary>
        /// <returns></returns>
        public static bool isDead(Player p)
        {
            return p.units.Count == 0;
        }

        /// <summary>
        /// Removes a unit from the current player's units.
        /// If no match is found for the specified unit, does nothing.
        /// </summary>
        /// <param name="unit"></param>
        public void removeUnit(AUnit unit)
        {
            if (units.Contains(unit))
                units.Remove(unit);
        }

        /// <summary>
        /// Creates the serializable data object representing the current player.
        /// </summary>
        /// <returns></returns>
        public PlayerData toData()
        {
            PlayerData data = new PlayerData();
            data.race = race;
            data.name = name;
            data.points = points;
            data.units = new List<AUnit>();
            UnitFactory factory = new UnitFactory();
            foreach (AUnit unit in units)
                data.units.Add(factory.copyUnit(unit));

            return data;
        }
    }
}
