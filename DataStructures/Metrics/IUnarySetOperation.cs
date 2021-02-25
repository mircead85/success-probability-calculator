using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface IUnarySetOperation : ISetOperation
    {
        /// <summary>
        /// If the result is not in the support set, the return result is null.
        /// </summary>
        Func<ISetElement, ISetElement> Operation { get; }
    }
}
