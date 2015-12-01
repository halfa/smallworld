using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This interface is a template for all SmallWorld save managers.
    /// </summary>
    public interface ISaveManager
    {
        /// <summary>
        /// Read and write access to the game to save.
        /// </summary>
        Game savable { get; set; }

        /// <summary>
        /// Saves the game at the specified filePath.
        /// </summary>
        /// <param name="filePath"></param>
        void save(string filePath);
    }
}