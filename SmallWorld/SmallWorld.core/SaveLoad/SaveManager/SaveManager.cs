using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for save managers for the SmallWorld application.
    /// </summary>
    public class SaveManager : ISaveManager
    {
        /// <summary>
        /// Constructor for the SaveManager class.
        /// Sets the savable field's value to null.
        /// </summary>
        public SaveManager()
        {
            savable = null;
        }

        /// <summary>
        /// Read and write access to the game to save when calling the save method.
        /// </summary>
        public Game savable { get; set; }

        /// <summary>
        /// Saves the current saveManager's savable field to the specified filePath.
        /// Serializes the savable in xml format, and then saves it.
        /// </summary>
        /// <param name="filePath"></param>
        public void save(string filePath)
        {
            string dir = "Saves";
            System.IO.Directory.CreateDirectory(dir);
            XmlSerializer ser = new XmlSerializer(typeof(GameData));
            using (var file = File.OpenWrite(dir + "\\" + filePath + ".xml"))
            {
                ser.Serialize(file, savable.toData());
                file.Close();
            }
        }
    }
}
 