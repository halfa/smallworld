using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Position : ISavable
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public Position(Position position)
        {
            throw new System.NotImplementedException();
        }

        ~Position()
        {
            throw new System.NotImplementedException();
        }

        public int x
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int y
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public System.SerializableAttribute toData()
        {
            throw new NotImplementedException();
        }

        public void loadData(System.SerializableAttribute data)
        {
            throw new System.NotImplementedException();
        }
    }
}