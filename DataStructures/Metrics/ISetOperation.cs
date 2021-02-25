using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface ISetOperation
    {
        ISet SupportSet { get; }

        /// <summary>
        /// Returns null if no neutral element with regard to support set.
        /// </summary>
        ISetElement NeutralElement { get; }
    }
}
