using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface IMetric: ICloneable
    {
        IOrderedSet SupportSet { get; }
    }

    public interface IMetric<TValue>: IMetric
        where TValue:IMetricKind
    {
        IMetric<TValue> Add(IMetric<TValue> leftSide, IMetric<TValue> rightSide);
        IMetric<TValue> Substract(IMetric<TValue> leftSide, IMetric<TValue> rightSide);

        void AddWith(IMetric<TValue> otherMetric);
        void Substract(IMetric<TValue> toSubstract);
    }
}
