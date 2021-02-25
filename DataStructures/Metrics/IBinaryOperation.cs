using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface IBinarySetOperation: ISetOperation
    {
        bool IsCommutative { get; }
        bool IsAssociative { get; }

        /// <summary>
        /// If the result is not in the support set, the return result is null.
        /// </summary>
        Func<ISetElement, ISetElement, ISetElement> Operation { get; }
        
        /// <summary>
        /// Returns null if no inverse operation is supported.
        /// </summary>
        IUnarySetOperation InverseWithRegardToOperation { get; }
    }
}
