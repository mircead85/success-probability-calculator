using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface IOrderedSetElement : ISetElement, IComparable<IOrderedSetElement>
    {
        ISetElement SetElement { get; }

        string OrderRelationID { get; }
    }
}
