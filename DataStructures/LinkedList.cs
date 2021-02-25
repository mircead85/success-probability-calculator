using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    [Serializable]
    public class LinkedList<TValue>:ILinkedList<TValue>
    {
        public LinkedList()
        {
        }

        protected int? _Count = 0;
        public int? Count
        {
            get { return _Count; }
        }

        protected ILinkedListNode<TValue> _Head = null;
        public ILinkedListNode<TValue> Head
        {
            get { return _Head; }
        }

        protected ILinkedListNode<TValue> _Tail = null;
        public ILinkedListNode<TValue> Tail
        {
            get { return _Tail; }
        }

        public ILinkedListNode<TValue> InsertAtHead(TValue newVal = default(TValue))
        {
            LinkedListNode<TValue> node = new LinkedListNode<TValue>(newVal);
            node.Next = _Head;
            if (_Head != null)
                _Head.Previous = node;
            else
                _Tail = node;
            _Head = node;

            if(Count!=null)
                _Count++;
            return node;
        }

        public void InsertAtHead(ILinkedListNode<TValue> nodeToInsert)
        {
            if (nodeToInsert == null)
                throw new ArgumentNullException();

            nodeToInsert.Next = _Head;
            if (_Head != null)
                _Head.Previous = nodeToInsert;
            else
                _Tail = nodeToInsert;
            _Head = nodeToInsert;
            nodeToInsert.Previous = null;
            if (Count != null)
                _Count++;
        }

        public ILinkedListNode<TValue> InsertAtTail(TValue newVal = default(TValue))
        {
            LinkedListNode<TValue> node = new LinkedListNode<TValue>(newVal);
            node.Previous = _Tail;
            if (_Tail != null)
                _Tail.Next = node;
            else
                _Head = node;
            _Tail = node;
            if (Count != null)
                _Count++;
            return node;
        }

        public void InsertAtTail(ILinkedListNode<TValue> nodeToInsert)
        {
            nodeToInsert.Previous = _Tail;
            if (_Tail != null)
                _Tail.Next = nodeToInsert;
            else
                _Head = nodeToInsert;
            _Tail = nodeToInsert;
            nodeToInsert.Next = null;
            _Count++;
        }

        public void RemoveFromList(ILinkedListNode<TValue> nodeToRemove)
        {
            if (nodeToRemove.Previous != null)
                nodeToRemove.Previous.Next = nodeToRemove.Next;
            if (nodeToRemove.Next != null)
                nodeToRemove.Next.Previous = nodeToRemove.Previous;
            if (_Head == nodeToRemove)
                _Head = nodeToRemove.Next;
            if (_Tail == nodeToRemove)
                _Tail = nodeToRemove.Previous;
            if (Count != null)
                _Count--;
        }

        public void TrimEndAt(ILinkedListNode<TValue> lastNode, bool bInclusive)
        {
            if (lastNode == null)
                throw new ArgumentNullException();

            if (bInclusive)
                lastNode = lastNode.Previous;

            if (lastNode == null)
            {
                _Head = null;
                _Tail = null;
                _Count = 0;
            }
            else
            {
                lastNode.Next = null;
                _Count = null;
            }
        }
    }

    [Serializable]
    public class LinkedListNode<TValue> : ILinkedListNode<TValue>
    {
        public LinkedListNode()
        {
            Value = default(TValue);
            Next = null;
            Previous = null;
        }

        public LinkedListNode(TValue val)
            : this()
        {
            Value = val;
        }

        public TValue Value
        {
            get;
            set;
        }

        public ILinkedListNode<TValue> Next
        {
            get;
            set;
        }

        public ILinkedListNode<TValue> Previous
        {
            get;
            set;
        }
    }
}
