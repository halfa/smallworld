using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for a unit factory.
    /// It provides methods to instanciate unit.
    /// </summary>
    public class UnitFactory
    {
        /// <summary>
        /// Default constructor for the UnitFactory class.
        /// </summary>
        public UnitFactory()
        {
        }

        /// <summary>
        /// Creates a new HumanUnit.
        /// </summary>
        /// <returns></returns>
        public HumanUnit createHumanUnit()
        {
            return new HumanUnit();
        }

        /// <summary>
        /// Creates a memberwise copy of the specified HumanUnit.
        /// </summary>
        /// <param name="humanUnit"></param>
        /// <returns></returns>
        public HumanUnit createHumanUnit(HumanUnit humanUnit)
        {
            return new HumanUnit(humanUnit);
        }

        /// <summary>
        /// Creates a new ElfUnit.
        /// </summary>
        /// <returns></returns>
        public ElfUnit createElfUnit()
        {
            return new ElfUnit();
        }

        /// <summary>
        /// Creates a memberwise copy of the specified ElfUnit.
        /// </summary>
        /// <param name="elfUnit"></param>
        /// <returns></returns>
        public ElfUnit createElfUnit(ElfUnit elfUnit)
        {
            return new ElfUnit(elfUnit);
        }

        /// <summary>
        /// Creates a new OrcUnit.
        /// </summary>
        /// <returns></returns>
        public OrcUnit createOrcUnit()
        {
            return new OrcUnit();
        }

        /// <summary>
        /// Creates a memberwise copy of the specified OrcUnit.
        /// </summary>
        /// <param name="orcUnit"></param>
        /// <returns></returns>
        public OrcUnit createOrcUnit(OrcUnit orcUnit)
        {
            return new OrcUnit(orcUnit);
        }
    }
}