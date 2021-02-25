using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class AVLOrderedDictionary<TValue> : IOrderedDictionary<TValue>
    {
        public class workingOrderedDictonaryEntry : IOrderedDictionaryEntry<TValue>
        {
            public int Count
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Key
            {
                get;
                set;
            }

            public TValue Value
            {
                get;
                set;
            }

            public int NoElementsLesserThan
            {
                get;
                set;
            }

            public int NoElementsLargerThan
            {
                get;
                set;
            }

            public IOrderedDictionaryEntry<TValue> NextLargerEntry
            {
                get
                {
                    if (!IsLeaf)
                        throw new InvalidOperationException("Cannot get next entry on non-leaf.");

                    return RightLeaf;
                }
            }

            public IOrderedDictionaryEntry<TValue> PreviousSmallerEntry
            {
                get
                {
                    if (!IsLeaf)
                        throw new InvalidOperationException("Cannot get previous entry on non-leaf.");

                    return LeftLeaf;
                }
            }

            public workingOrderedDictonaryEntry Parent
            {
                get;
                set;
            }

            public workingOrderedDictonaryEntry LeftNode
            {
                get;
                set;
            }

            public workingOrderedDictonaryEntry RightNode
            {
                get;
                set;
            }

            public bool IsLeaf
            {
                get
                {
                    return (LeftNode == null && RightNode == null);
                }
            }

            public workingOrderedDictonaryEntry LeftLeaf { get; set; }
            public workingOrderedDictonaryEntry RightLeaf { get; set; }

            public static workingOrderedDictonaryEntry MakeLeaf(int key, TValue val, workingOrderedDictonaryEntry leftLeaf, workingOrderedDictonaryEntry rightLeaf)
            {
                var result = new workingOrderedDictonaryEntry(key, val);
                result.Count = 1;
                result.Height = 1;

                result.RightLeaf = rightLeaf;
                result.LeftLeaf = leftLeaf;

                if (leftLeaf != null)
                    leftLeaf.RightLeaf = result;

                if (rightLeaf != null)
                    rightLeaf.LeftLeaf = result;

                return result;
            }

            public workingOrderedDictonaryEntry(int key, TValue val)
            {
                Key = key;
                Value = val;
                Parent = null;
                LeftNode = null;
                RightNode = null;
                LeftLeaf = null;
                RightLeaf = null;
                Count = 0;
                Height = 0;
            }

            protected virtual void UpdateAggregates()
            {
                Height = 1;
                if (IsLeaf)
                {
                    Count = 1;
                    return;
                }
                Count = 0;
                Count += LeftNode.Count;
                Count += RightNode.Count;

                Height += Math.Max(LeftNode.Height, RightNode.Height);
            }

            public void Update()
            {
                UpdateAggregates();

                if (Math.Abs(LeftNode.Height - RightNode.Height) < 2)
                    return;

                if (LeftNode.Height > RightNode.Height)
                {
                    if (LeftNode.LeftNode != null)
                        if (LeftNode.LeftNode.Height == RightNode.Height)
                            LeftNode.RotateLeft();
                    this.RotateRight();
                }
                else
                {
                    if (RightNode.RightNode != null)
                        if (RightNode.RightNode.Height < LeftNode.Height)
                            RightNode.RotateRight();
                    this.RotateLeft();
                }
            }

            protected void RotateLeft()
            {
                if (LeftNode == null || RightNode == null)
                    return;

                if (RightNode.LeftNode == null || RightNode.RightNode == null)
                    return;

                var rightLeft = RightNode.LeftNode;
                var rightRight = RightNode.RightNode;
                var right = RightNode;
                var left = LeftNode;

                ExchangeData(RightNode);

                RightNode = rightRight;
                RightNode.Parent = this;
                LeftNode = right;
                LeftNode.Parent = this;
                right.LeftNode = left;
                left.Parent = right;
                right.RightNode = rightLeft;
                rightLeft.Parent = right;

                LeftNode.UpdateAggregates();
                UpdateAggregates();
            }

            protected void RotateRight()
            {
                if (LeftNode == null || RightNode == null)
                    return;

                if (LeftNode.LeftNode == null || LeftNode.RightNode == null)
                    return;

                var leftLeft = LeftNode.LeftNode;
                var leftRight = LeftNode.RightNode;
                var right = RightNode;
                var left = LeftNode;

                ExchangeData(LeftNode);

                LeftNode = leftLeft;
                LeftNode.Parent = this;
                RightNode = left;
                RightNode.Parent = this;
                RightNode.LeftNode = leftRight;
                leftRight.Parent = RightNode;
                RightNode.RightNode = right;
                right.Parent = RightNode;

                RightNode.UpdateAggregates();
                UpdateAggregates();
            }

            protected virtual void ExchangeData(workingOrderedDictonaryEntry withWhom)
            {
                var oldKey = this.Key;
                var oldVal = this.Value;

                this.Key = withWhom.Key;
                this.Value = withWhom.Value;

                withWhom.Key = oldKey;
                withWhom.Value = oldVal;
            }
        }

        protected workingOrderedDictonaryEntry _Root;

        public IOrderedDictionaryEntry<TValue> Root
        {
            get
            {
                return _Root;
            }
        }

        public AVLOrderedDictionary()
        {
            _Root = null;
        }

        protected workingOrderedDictonaryEntry GrossFind(int key)
        {
            if (_Root == null) return null;
            if (_Root.IsLeaf)
            {
                return _Root;
            }

            int noLesserThan = 0;
            int noGreaterThan = 0;

            workingOrderedDictonaryEntry currentNode = _Root;
            while (!currentNode.IsLeaf)
            {
                if (key < currentNode.Key)
                    currentNode = currentNode.LeftNode;
                else
                {
                    noLesserThan += currentNode.LeftNode.Count;
                    currentNode = currentNode.RightNode;
                }
            }

            if (key < currentNode.Key)
                noGreaterThan = Count - noLesserThan;
            else if (currentNode.Key < key)
            {
                noLesserThan++;
                noGreaterThan = Count - noLesserThan;
            }
            else
                noGreaterThan = Count - 1 - noLesserThan;

            currentNode.NoElementsLesserThan = noLesserThan;
            currentNode.NoElementsLargerThan = noGreaterThan;

            return currentNode;
        }

        protected void UpdateTreeStructureUpwards(workingOrderedDictonaryEntry startingWith)
        {
            while (startingWith != null)
            {
                startingWith.Update();
                startingWith = startingWith.Parent;
            }
        }

        public bool AddOrUpdate(int key, TValue val)
        {
            if (_Root == null)
                _Root = workingOrderedDictonaryEntry.MakeLeaf(key, val, null, null);
            else
            {
                var relevantLeaf = GrossFind(key);
                if (relevantLeaf.Key == key)
                {
                    relevantLeaf.Value = val;
                    return false;
                }
                else
                {
                    workingOrderedDictonaryEntry newLeaf = null;
                    if (key < relevantLeaf.Key)
                    {
                        newLeaf = workingOrderedDictonaryEntry.MakeLeaf(key, val, relevantLeaf.LeftLeaf, null);
                        relevantLeaf.LeftNode = newLeaf;
                        newLeaf.Parent = relevantLeaf;
                        relevantLeaf.RightNode = workingOrderedDictonaryEntry.MakeLeaf(relevantLeaf.Key, relevantLeaf.Value, newLeaf, relevantLeaf.RightLeaf);
                        relevantLeaf.RightNode.Parent = relevantLeaf;
                    }
                    else
                    {
                        newLeaf = workingOrderedDictonaryEntry.MakeLeaf(key, val, null, relevantLeaf.RightLeaf);
                        relevantLeaf.LeftNode = workingOrderedDictonaryEntry.MakeLeaf(relevantLeaf.Key, relevantLeaf.Value, relevantLeaf.LeftLeaf, newLeaf);
                        relevantLeaf.LeftNode.Parent = relevantLeaf;
                        relevantLeaf.RightNode = newLeaf;
                        relevantLeaf.RightNode.Parent = relevantLeaf;
                        relevantLeaf.Key = key;
                    }
                    relevantLeaf.Value = default(TValue);
                    relevantLeaf.LeftLeaf = null;
                    relevantLeaf.RightLeaf = null;

                    UpdateTreeStructureUpwards(relevantLeaf);
                }
            }

            return true;
        }

        public int Count
        {
            get
            {
                if (_Root == null)
                    return 0;

                return _Root.Count;
            }
        }

        public IOrderedDictionaryEntry<TValue> Find(int key)
        {
            var grossResult = GrossFind(key);
            if (grossResult == null)
                return null;
            if (grossResult.Key == key)
                return grossResult;
            else
                return null;
        }

        public IOrderedDictionaryEntry<TValue> FindFirstNoLesserThan(int key)
        {
            var grossResult = GrossFind(key);
            if (grossResult == null)
                return null;

            if (key <= grossResult.Key)
                return grossResult;

            var result = grossResult.NextLargerEntry;
            return result;
        }

        public IOrderedDictionaryEntry<TValue> FindLastNoLargerThan(int key)
        {
            var grossResult = GrossFind(key);
            if (grossResult == null)
                return null;

            if (key >= grossResult.Key)
                return grossResult;

            var result = grossResult.PreviousSmallerEntry;
            return result;
        }

        public int NoElementsLesserThan(int key)
        {
            if (_Root == null)
                return 0;
            var grossResult = GrossFind(key);
            return grossResult.NoElementsLesserThan;
        }

        public int NoElementsLargerThan(int key)
        {
            if (_Root == null)
                return 0;
            var grossResult = GrossFind(key);
            return grossResult.NoElementsLargerThan;
        }

        public bool Delete(int key)
        {
            var grossResult = GrossFind(key);
            if (grossResult.Key != key)
                return false;

            if (grossResult == _Root)
            {
                _Root = null;
            }
            else
            {
                workingOrderedDictonaryEntry remainingNode = null;
                if (grossResult == grossResult.Parent.LeftNode)
                {
                    grossResult.Parent.LeftNode = null;
                    remainingNode = grossResult.Parent.RightNode;
                }
                else
                {
                    grossResult.Parent.RightNode = null;
                    remainingNode = grossResult.Parent.LeftNode;
                }

                if (grossResult.Parent.Parent == null)
                {
                    _Root = remainingNode;
                }
                else
                {
                    if (grossResult.Parent == grossResult.Parent.Parent.LeftNode)
                        grossResult.Parent.Parent.LeftNode = remainingNode;
                    else
                        grossResult.Parent.Parent.RightNode = remainingNode;
                }

                remainingNode.Parent = grossResult.Parent.Parent;
                UpdateTreeStructureUpwards(grossResult.Parent.Parent);
            }

            return true;
        }
    }

}
