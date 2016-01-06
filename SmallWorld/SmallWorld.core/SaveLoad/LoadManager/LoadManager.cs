using System;
using System.IO;
using System.Xml.Serialization;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for load managers for the SmallWorld application.
    /// </summary>
    public class LoadManager : ILoadManager
    {
        /// <summary>
        /// Constructor for the SaveManager class.
        /// Sets the game field's value to null.
        /// </summary>
        public LoadManager()
        {
            game = null;
        }

        /// <summary>
        /// Read and write access to the game field.
        /// Used to store the loaded game after a call to the loadGame method.
        /// </summary>
        public Game game { get; set; }

        /// <summary>
        /// Loads game data from the specified file, which has previously been serialized and saved by a saveManager.
        /// Updates the game field to be the loaded game.
        /// If the file has been loaded, returns true. Returns false otherwise.
        /// If the file exists but the data it contains couldn't be deserialized, throws a new Exception.
        /// </summary>
        /// <param name="filePath"></param>
        public bool loadGame(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(GameData));
                GameData data = null;
                using (var file = File.OpenRead(filePath))
                {
                    data = (GameData)ser.Deserialize(file);
                    file.Close();
                }
                if (data == null)
                    throw new Exception("Error occured while loading the game data.");
                game = new Game(data);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
 