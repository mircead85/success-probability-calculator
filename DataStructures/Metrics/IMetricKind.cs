using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    /// <summary>
    /// Interface representing an algebric structure that may support additions, multiplications and negations.
    /// All structures MUST be associative.
    /// </summary>
    /// <remarks>Results of operations are always in the current IMetricKind (that of the current object).
    /// Parameters may be in a different IMetricKind only if that other IMetricKind is implicitly convertible to the current one.</remarks>
    public interface IMetricKind : ICloneable
    {
        bool IsAdditonCommutative { get; }
        bool IsMultiplicationCommutative { get; }

        IMetric Add(IMetric leftSide, IMetric rightSide); 
        IMetric Multiply(IMetric leftSide, IMetric rightSide);

        IMetric GetAdditiveInverse(IMetric val);
        IMetric GetMultiplicativeInverse(IMetric val);

        IMetric FromValue(object elementaryValue);

        IMetric AdditionNeutralElement { get; }
        IMetric MultiplicationNeutralElement { get; }

        int CompareValues(IMetric leftSide, IMetric rightSide);
    }
}
