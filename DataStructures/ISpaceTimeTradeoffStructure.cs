using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ISpaceTimeTradeoffStructure<TValue>
    {
        int SkipSize { get; }
        int MaxPosition { get; }

        TValue Get(int position);

        Func<TValue, TValue> nextValue { get; set; }

        void Compute(TValue initialVal);
    }

}
