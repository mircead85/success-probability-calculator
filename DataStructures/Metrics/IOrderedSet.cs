using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface IOrderedSet : ISet
    {
        IOrderedSetElement GetOrderedElement(ISetElement element, int whichRelation);
        IOrderedSetElement GetOrderedElement(ISetElement element, string whichRelation);

        List<IOrderRelation> OrderRelations { get; }
        IDictionary<string, IOrderRelation> OrderRelationsDictionary { get; }
    }
}
