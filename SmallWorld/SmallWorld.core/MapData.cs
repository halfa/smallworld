using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public class MapData
    {
        private int _height;
        private int _width;
        private List<ITile> _tiles;
        private MapType _type;

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

        public MapType type
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<ITile> tiles
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