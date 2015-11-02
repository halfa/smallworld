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
        private IMapSetup _mapSetup;

        public Map(MapType type)
        {
            /*
            This method should create a new IMapSetup and set it as the coresponding attribute according to the MapType.
            */
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

        public IMapSetup mapSetup
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void setupMap()
        {
            throw new System.NotImplementedException();
        }
    }
}