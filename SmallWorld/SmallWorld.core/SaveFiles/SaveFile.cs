using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class SaveFile : ISaveFile
    {
        private String _filePath;
        private string _data;

        public SaveFile(String filePath, string data)
        {
            throw new System.NotImplementedException();
        }

        ~SaveFile()
        {
            throw new System.NotImplementedException();
        }

        public String filePath
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string data
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void saveToDisk()
        {
            throw new System.NotImplementedException();
        }
    }
}