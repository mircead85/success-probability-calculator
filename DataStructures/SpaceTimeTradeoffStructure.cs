using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    [Serializable]
    public class SpaceTimeTradeoffStructure<TValue> : ISpaceTimeTradeoffStructure<TValue>
    {
        protected List<TValue> savedValues = new List<TValue>();

        protected ILRUCache<int, TValue> cache;

        public SpaceTimeTradeoffStructure(int skipSize, int maxPosition, int cacheSize = 10)
        {
            SkipSize = skipSize;
            _MaxPosition = maxPosition;
            bComputed = false;

            cache = new LRUCache<int, TValue>(cacheSize);
        }

        public SpaceTimeTradeoffStructure(int skipSize, int maxPosition, Func<TValue, TValue> transformationFunc)
            :this(skipSize, maxPosition)
        {
            nextValue = transformationFunc;
        }

        public TValue InitialValue
        {
            get;
            protected set;
        }

        protected bool bComputed;

        protected int _MaxPosition;
        public int MaxPosition
        {
            get { return _MaxPosition; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid max position.");
                _MaxPosition = value;
                bComputed = false;
            }
        }

        public void Compute(TValue initialVal)
        {
            savedValues.Clear();

            InitialValue = initialVal;
            TValue curVal = initialVal;
            int curPos;
            for (curPos = 0; curPos <= MaxPosition; curPos++)
            {
                if (curPos % SkipSize == 0)
                    savedValues.Add(curVal);

                curVal = nextValue(curVal);
            }

            bComputed = true;
        }

        public int SkipSize
        {
            get;
            protected set;
        }

        public TValue Get(int position)
        {
            if (position < 0 || position > MaxPosition)
                throw new ArgumentException();

            if (cache.Contains(position))
                return cache[position];

            int startLoc = position / SkipSize;
            position %= SkipSize;

            var startVal = savedValues[startLoc];
            while (position > 0)
            {
                startVal = nextValue(startVal);
                position--;
            }
            cache[position] = startVal;
            return startVal;
        }

        public Func<TValue, TValue> nextValue
        {
            get;
            set;
        }
    }
}
