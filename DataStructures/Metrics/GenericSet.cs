using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    [Serializable]
    public class GenericSet: ISet
    {
        public string UniqueSetID { get; protected set; }

        public GenericSet(Type supportType, Func<object, bool> belongsToSetFunc, string uniqueSetID = null)
        {
            if (uniqueSetID == null)
                uniqueSetID = Guid.NewGuid().ToString();

            UniqueSetID = uniqueSetID;
            SupportType = supportType;
            oBelongsToSetDelegate = belongsToSetFunc;

            MaintainCreatedElementsInHash = true;

            UnarySetOperations = new List<IUnarySetOperation>();
            BinarySetOperations = new List<IBinarySetOperation>();
            UnarySetOperationsDictionary = new Dictionary<string, int>();
            BinarySetOperationsDictionary = new Dictionary<string, int>();
        }

        private bool _MaintainCreatedElementsInHash = false;
        public bool MaintainCreatedElementsInHash
        {
            get
            {
                return _MaintainCreatedElementsInHash;
            }
            set
            {
                var oldValue = _MaintainCreatedElementsInHash;
                if (value == oldValue)
                    return;

                if (value == false)
                    RawValueToElement = null;
                else
                    RawValueToElement = new Hashtable();

                _MaintainCreatedElementsInHash = value;
            }
        }

        protected Hashtable RawValueToElement { get; private set; }

        public Type SupportType
        {
            get;
            protected set;
        }

        protected virtual void CheckObjectType(object candidateElement)
        {
            if (!SupportType.IsAssignableFrom(candidateElement.GetType()))
                throw new InvalidRawValueException("Invalid support type for specified element.");
        }

        protected Func<object, bool> oBelongsToSetDelegate { get; set; }

        public virtual bool BelongsToSet(object candidateElement)
        {
            if (candidateElement == null)
                return false;

            CheckObjectType(candidateElement);
            return oBelongsToSetDelegate(candidateElement);
        }

        public virtual ISetElement this[object rawValue]
        {
            get 
            {
                if (rawValue == null)
                    return null;

                CheckObjectType(rawValue);
                ISetElement result = null;
                if(MaintainCreatedElementsInHash)
                    result = RawValueToElement[rawValue] as ISetElement;
                if (result != null)
                    return result;

                result = new GenericSetElement(this, rawValue);
                if (MaintainCreatedElementsInHash)
                    RawValueToElement[rawValue] = result;

                return result;
            }
        }

        public IList<IUnarySetOperation> UnarySetOperations { get; private set; }

        public IDictionary<string, int> UnarySetOperationsDictionary { get; private set; }

        public IList<IBinarySetOperation> BinarySetOperations { get; private set; }

        public IDictionary<string, int> BinarySetOperationsDictionary { get; private set; }

        public virtual ISetElement ConvertElementFromOtherSet(ISetElement otherSetElement, bool Implicitly)
        {
            if (otherSetElement.SupportSet.Equals(this))
                return this[otherSetElement.RawValue]; //Just in case the sets are different objects with different hashtables.

            return null;
        }

        public virtual ISetElement ConvertToElementInOtherSet(ISetElement elementToConvert, ISet targetSet, bool Implicitly)
        {
            if(!elementToConvert.SupportSet.Equals(this))
                throw new ArgumentException("Cannot convert element from a different set to something else.");

            return null;
        }

        public virtual bool Equals(ISet other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (other is GenericSet)
                return ((GenericSet)other).UniqueSetID == UniqueSetID;

            return false;
        }

        public virtual int AddOperation(ISetOperation operation, string name)
        {
            if (operation is IBinarySetOperation)
            {
                BinarySetOperations.Add((IBinarySetOperation)operation);
                BinarySetOperationsDictionary[name] = BinarySetOperations.Count - 1;
            }
            else if (operation is IUnarySetOperation)
            {
                UnarySetOperations.Add((IUnarySetOperation)operation);
                UnarySetOperationsDictionary[name] = UnarySetOperations.Count - 1;
            }

            throw new ArgumentException("Unrecognized kind of operation.");
        }
    }


    public class GenericSet<TSupportValue> : GenericSet, ISet<TSupportValue>
    {
        public GenericSet(Func<TSupportValue, bool> belongsToSetFunc, string uniqueSetID = null)
            : base(typeof(TSupportValue), null, uniqueSetID)
        {
            tBelongsToSetFunc = belongsToSetFunc;
            oBelongsToSetDelegate = elem => belongsToSetFunc(((TSupportValue)elem));
        }

        protected Func<TSupportValue, bool> tBelongsToSetFunc { get; set; }

        public bool BelongsToSet(TSupportValue candidateElement)
        {
            if (candidateElement == null)
                return false;

            return tBelongsToSetFunc(candidateElement);
        }

        public ISetElement<TSupportValue> this[TSupportValue rawValue]
        {
            get 
            {
                if (rawValue == null)
                    return null;

                ISetElement<TSupportValue> result = null;
                if(MaintainCreatedElementsInHash)
                    result = RawValueToElement[rawValue] as ISetElement<TSupportValue>;
                if (result != null)
                    return result;

                result = new GenericSetElement<TSupportValue>(this, rawValue);
                if (MaintainCreatedElementsInHash)
                    RawValueToElement[rawValue] = result;

                return result;
            }
        }
    }
}
