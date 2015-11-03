using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class SaveManager : ISaveManager
    {
        private List<IHashable> _hashables;
        private ISaveFile _saveFile;
        private SaveManager INSTANCE;

        private SaveManager()
        {
            throw new System.NotImplementedException();
        }

        ~SaveManager()
        {
            throw new System.NotImplementedException();
        }

        public ISaveFile saveFile
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<IHashable> hashables
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

        public void save()
        {
            throw new System.NotImplementedException();
        }

        public void addHashable(IHashable hashable)
        {
            throw new System.NotImplementedException();
        }

        public void clearHashables()
        {
            throw new System.NotImplementedException();
        }

        public void save(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}