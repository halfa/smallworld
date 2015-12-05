using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This interface is a template for all SmallWorld load managers.
    /// </summary>
    public interface ILoadManager
    {
        /// <summary>
        /// Read and write access to the game field.
        /// Used to store the loaded game after a call to the loadGame method.
        /// </summary>
        Game game { get; set; }

        /// <summary>
        /// Loads a game object from the specified file and updates the current load manager's game field.
        /// If the object has been loaded, returns true. Returns false otherwise.
        /// </summary>
        /// <param name="filePath"></param>
        bool loadGame(string filePath);
    }
}