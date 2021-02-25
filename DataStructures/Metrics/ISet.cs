using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface ISet: IEquatable<ISet>
    {
        //string UniqueSetID { get; }
        Type SupportType { get; }

        bool BelongsToSet(object rawValue);
        ISetElement this[object rawValue] { get; }

        IList<IUnarySetOperation> UnarySetOperations { get; }
        IDictionary<string, int> UnarySetOperationsDictionary { get; }

        IList<IBinarySetOperation> BinarySetOperations { get; }
        IDictionary<string, int> BinarySetOperationsDictionary { get; }

        ISetElement ConvertElementFromOtherSet(ISetElement otherSetElement, bool Implicitly);
        ISetElement ConvertToElementInOtherSet(ISetElement elementToConvert, ISet targetSet, bool Implicitly);
    }

    public interface ISet<TSupportType> : ISet
    {
        bool BelongsToSet(TSupportType candidateElement);
        
        ISetElement<TSupportType> this[TSupportType rawValue] { get; }
    }
}
