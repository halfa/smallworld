﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class SaveManager : ISaveManager
    {
        private List<ISavable> _savables;
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

        public List<ISavable> savables
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

        public void addHashable(ISavable savable)
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