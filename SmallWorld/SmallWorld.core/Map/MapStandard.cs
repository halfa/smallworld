﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public class MapStandard : IMap
    {
        private int _height;
        private List<ITile> _tiles;
        private int _width;

        public MapStandard()
        {
            throw new System.NotImplementedException();
        }

        ~MapStandard()
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
    }
}
