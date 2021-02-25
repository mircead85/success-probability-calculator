using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    public interface IOrderedDictionaryEntry<TValue>
    {
        int Key { get; }
        TValue Value { get; set; }

        IOrderedDictionaryEntry<TValue> NextLargerEntry { get; }
        IOrderedDictionaryEntry<TValue> PreviousSmallerEntry { get; }

        int NoElementsLesserThan { get; }
        int NoElementsLargerThan { get; }

        int Height { get; }
    }

    public interface IOrderedDictionary<TValue>
    {
        bool AddOrUpdate(int key, TValue val);

        IOrderedDictionaryEntry<TValue> Find(int key);
        IOrderedDictionaryEntry<TValue> FindFirstNoLesserThan(int key);
        IOrderedDictionaryEntry<TValue> FindLastNoLargerThan(int key);
        //IOrderedDictionaryEntry<TValue> FindKthLargestElement(int kValue);
        int NoElementsLesserThan(int key);
        int NoElementsLargerThan(int key);

        bool Delete(int key);

        IOrderedDictionaryEntry<TValue> Root { get; }

        int Count { get; }
    }

    public class OrderedDictonaryEntry<TValue> : IOrderedDictionaryEntry<TValue>
    {
        protected IOrderedDictionaryEntry<TValue> _UnderlyingEntity;

        public OrderedDictonaryEntry(IOrderedDictionaryEntry<TValue> underlyingEntity)
        {
            _UnderlyingEntity = underlyingEntity;
        }

        public int Key
        {
            get { return _UnderlyingEntity.Key; }
        }

        public TValue Value
        {
            get
            {
                return _UnderlyingEntity.Value;
            }
            set
            {
                _UnderlyingEntity.Value = value;
            }
        }

        public IOrderedDictionaryEntry<TValue> NextLargerEntry
        {
            get
            {
                if (_UnderlyingEntity.NextLargerEntry != null)
                    return new OrderedDictonaryEntry<TValue>(_UnderlyingEntity.NextLargerEntry);
                else return null;
            }
        }

        public IOrderedDictionaryEntry<TValue> PreviousSmallerEntry
        {
            get
            {
                if (_UnderlyingEntity.PreviousSmallerEntry != null)
                    return new OrderedDictonaryEntry<TValue>(_UnderlyingEntity.PreviousSmallerEntry);
                else return null;
            }
        }

        public int NoElementsLesserThan
        {
            get
            {
                return _UnderlyingEntity.NoElementsLesserThan;
            }
        }

        public int NoElementsLargerThan
        {
            get
            {
                return _UnderlyingEntity.NoElementsLargerThan;
            }
        }

        public int Height
        {
            get
            {
                return _UnderlyingEntity.Height;
            }
        }
    }

}
