using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class Map : IMap
    {
        private int _height;
        private List<ITile> _tiles;
        private int _width;

        public Map(MapType type)
        {
            throw new System.NotImplementedException();
        }

        ~Map()
        {
            throw new System.NotImplementedException();
        }

        public int height
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<ITile> tiles
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int width
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}