using System;
using System.Collections.Generic;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for the serializable game settings.
    /// </summary>
    [Serializable]
    public class GameSettings
    {
        /// <summary>
        /// Constructor for the GameSettings class.
        /// </summary>
        public GameSettings()
        {
            playersNames = new List<string>();
            playersRaces = new List<Races>();
        }

        /// <summary>
        /// Read and write access to the current gameSettings' mapType field.
        /// </summary>
        public MapType mapType { get; set; }

        /// <summary>
        /// Read and write access to the current gameSettings' nbPlayers field.
        /// </summary>
        public int nbPlayers { get; set; }

        /// <summary>
        /// Read and write access to the current gameSettings' playersNames field.
        /// </summary>
        public List<string> playersNames { get; set; }

        /// <summary>
        /// Read and write access to the current gameSettings' playersRaces field.
        /// </summary>
        public List<Races> playersRaces { get; set; }

        /// <summary>
        /// Read and write access to the current gameSettings' turnLimit field.
        /// </summary>
        public int turnLimit { get; set; }

        /// <summary>
        /// Read and write access to the current gameSettings' unitLimit field.
        /// </summary>
        public int unitLimit { get; set; }

        /// <summary>
        /// Sets the current gameSettings' fields according to its map type.
        /// </summary>
        public void setFieldsAccordingToMapType()
        {
            nbPlayers = 2;

            switch(mapType)
            {
                case MapType.Demo:
                    turnLimit = 5;
                    unitLimit = 4;
                    break;
                case MapType.Small:
                    turnLimit = 20;
                    unitLimit = 6;
                    break;
                case MapType.Standard:
                    turnLimit = 30;
                    unitLimit = 8;
                    break;
                default:
                    turnLimit = 0;
                    unitLimit = 0;
                    break;
            }
        }

        /// <summary>
        /// Determines if the values of the curent gameSettings are valid according to the game rules.
        /// </summary>
        /// <returns></returns>
        public bool areValid()
        {
            for (int i = 0; i < nbPlayers - 1; i++)
                for(int j = 1; j < nbPlayers; j++)
                    if (playersNames[i].Equals(playersNames[j]) || playersRaces[i] == playersRaces[j])
                        return false;
            
            return true;
        }
    }
}