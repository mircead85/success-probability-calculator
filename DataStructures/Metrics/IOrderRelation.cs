using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface IOrderRelation
    {
        ISet SupportSet { get; }

        bool IsTotalOrder { get; }

        /// <summary>
        /// Returns null if the two elements are not comparable.
        /// </summary>
        Func<ISetElement, ISetElement, int?> OrderRelation { get; }

        /// <summary>
        /// Gets the rank (in ascending order) of the specified element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Returns null if the rank cannot be known.</returns>
        int? RankOfElement(ISetElement element);
    }
}
