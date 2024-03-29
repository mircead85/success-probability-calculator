﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    [Serializable]
    public class LRUCache<TKey, TValue> : ILRUCache<TKey, TValue>
    {
        protected LinkedList<KeyValuePair<TKey, TValue>> cacheContent;
        protected Hashtable keyToLLnode;

        public LRUCache(int maxSize)
        {
            if (maxSize < 1)
                throw new ArgumentException();

            _MaxSize = maxSize;
            keyToLLnode = new Hashtable();
            cacheContent = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        public int _MaxSize;
        public int MaxSize
        {
            get
            {
                return _MaxSize;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                while (cacheContent.Count > value)
                {
                    RemoveLRUElement();
                }
                _MaxSize = value;
            }
        }

        protected void RemoveLRUElement()
        {
            if (cacheContent.Tail == null)
                return;
            var keyToRemove = cacheContent.Tail.Value;
            keyToLLnode.Remove(keyToRemove.Key);
            cacheContent.RemoveFromList(cacheContent.Tail);
        }

        public bool Contains(TKey key)
        {
            return keyToLLnode.Contains(key);
        }

        public TValue this[TKey key]
        {
            get
            {
                var llNode = keyToLLnode[key] as ILinkedListNode<KeyValuePair<TKey,TValue>>;
                if (llNode == null)
                    throw new ArgumentOutOfRangeException("Specified key is not in LRU cache.");
                    
                cacheContent.RemoveFromList(llNode);
                cacheContent.InsertAtHead(llNode);
                
                return llNode.Value.Value;
            }
            set
            {
                var llNode = keyToLLnode[key] as ILinkedListNode<KeyValuePair<TKey,TValue>>;
                if (llNode == null)
                {
                    if (cacheContent.Count > _MaxSize)
                        RemoveLRUElement();
                    llNode = cacheContent.InsertAtHead(new KeyValuePair<TKey, TValue>(key, value));
                    keyToLLnode[key] = llNode;
                }
                else
                {
                    cacheContent.RemoveFromList(llNode);
                    cacheContent.InsertAtHead(llNode);
                    llNode.Value = new KeyValuePair<TKey, TValue>(key, value);
                }
            }
        }
    }
}
