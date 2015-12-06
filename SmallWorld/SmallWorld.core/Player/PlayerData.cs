using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the serializable game player data.
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        /// <summary>
        /// Read and write access to the current playerData's name field.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Read and write access to the current playerData's points field.
        /// </summary>
        public int points { get; set; }

        /// <summary>
        /// Read and write access to the current playerData's race field.
        /// </summary>
        public Races race { get; set; }

        /// <summary>
        /// Read and write access to the current playerData's units field.
        /// </summary>
        public List<AUnit> units { get; set; }

        /// <summary>
        /// Constructor for the PlayerData class.
        /// </summary>
        public PlayerData()
        {
            units = new List<AUnit>();
        }
    }
}