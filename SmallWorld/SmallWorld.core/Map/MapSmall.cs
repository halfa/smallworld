using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class MapSmall : IMap
    {
        private int _height;
        private List<ITile> _tiles;
        private int _width;

        public MapSmall()
        {
            throw new System.NotImplementedException();
        }

        ~MapSmall()
        {
            throw new System.NotImplementedException();
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
