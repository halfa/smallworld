using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class SaveManager : ISaveManager
    {
        private ISavable _savable;
        private SaveManager _INSTANCE;

        private SaveManager()
        {
            throw new System.NotImplementedException();
        }

        public ISavable savable
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public SaveManager INSTANCE
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        private String hashToSaveFormat()
        {
            throw new System.NotImplementedException();
        }

        public void save(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}