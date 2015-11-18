using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    [Serializable]
    public class PlayerData
    {
        private ARace _race;
        private string _name;
        private List<AUnit> _units;

        public ARace race
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string name
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<AUnit> units
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