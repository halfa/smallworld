using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class MapDemo : IMap
    {
        private int _height;
        private List<Tile> _tiles;
        private int _width;

        public MapDemo()
        {
            throw new System.NotImplementedException();
        }

        ~MapDemo()
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> tiles
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

        public int height
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int width
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
