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
        /// Unique instance of the LoadManager class (Single DP).
        /// </summary>
        private static LoadManager _INSTANCE = new LoadManager();

        /// <summary>
        /// Constructor for the SaveManager class.
        /// Sets the game field's value to null.
        /// </summary>
        private LoadManager()
        {
            game = null;
        }

        /// <summary>
        /// Read and write access to the game field.
        /// Used to store the loaded game after a call to the loadGame method.
        /// </summary>
        public Game game { get; set; }

        /// <summary>
        /// Read only access to the only LoadManager instance of the application.
        /// </summary>
        public static LoadManager INSTANCE { get; }

        /// <summary>
        /// Loads game data from the specified file, which has previously been serialized and saved by a saveManager.
        /// Updates the game field to be the loaded game.
        /// </summary>
        /// <param name="filePath"></param>
        public void loadGame(string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(GameData));
            GameData data = null;
            using (var file = File.OpenRead(filePath))
            {
                data = (GameData)ser.Deserialize(file);
                file.Close();
            }
            if (data == null)
                throw new Exception("Error occured while loading.");
            game = new Game(data);
            //throw new System.NotImplementedException();
        }
    }
}
 