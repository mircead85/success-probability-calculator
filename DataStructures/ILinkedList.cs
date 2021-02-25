using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ILinkedList<TValue>
    {
        int? Count { get; }

        ILinkedListNode<TValue> Head {get;}
        ILinkedListNode<TValue> Tail {get;}

        ILinkedListNode<TValue> InsertAtHead(TValue newVal = default(TValue));
        void InsertAtHead(ILinkedListNode<TValue> nodeToInsert);
        ILinkedListNode<TValue> InsertAtTail(TValue newVal = default(TValue));
        void InsertAtTail(ILinkedListNode<TValue> nodeToInsert);

        void RemoveFromList(ILinkedListNode<TValue> nodeToRemove);
        void TrimEndAt(ILinkedListNode<TValue> lastNode, bool bInclusive);
    }

    public interface ILinkedListNode<TValue>
    {
        TValue Value { get; set; }

        ILinkedListNode<TValue> Next { get; set; }
        ILinkedListNode<TValue> Previous { get; set; }
    }
}
