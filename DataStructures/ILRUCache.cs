using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ILRUCache<TKey, TValue>
    {
        int MaxSize { get; set; }
        bool Contains(TKey key);
        TValue this[TKey key] { get; set; }
    }
}
