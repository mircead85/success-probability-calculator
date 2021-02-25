using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    [Serializable]
    public class GenericSetElement : ISetElement
    {
        public GenericSetElement(ISet supportSet, object rawValue)
        {
            SupportSet = supportSet;
            if (SupportSet.BelongsToSet(rawValue))
                RawValue = rawValue;
            else
                throw new ArgumentException("Specified rawValue does not belong to specified set.");
        }
        
        public ISet SupportSet
        {
            get;
            private set;
        }

        public object RawValue
        {
            get;
            private set;
        }
                
        public ISetElement PerformUnaryOperation(int operationID)
        {
            return SupportSet.UnarySetOperations[operationID].Operation(this);
        }

        public ISetElement PerformUnaryOperation(string operationID)
        {
            return PerformUnaryOperation(SupportSet.UnarySetOperationsDictionary[operationID]);
        }

        public ISetElement PerformBinaryOperation(int operationID, ISetElement rightSide)
        {
            if (!SupportSet.Equals(rightSide.SupportSet))
                rightSide = rightSide.ConvertToImplicitly(SupportSet);
            
            if (rightSide == null)
                throw new ArgumentException("Operand is null or not implicitly convertible to an element in the same set.");

            return SupportSet.BinarySetOperations[operationID].Operation(this, rightSide);
        }


        public ISetElement PerformBinaryOperation(string operationID, ISetElement rightSide)
        {
            return PerformBinaryOperation(SupportSet.BinarySetOperationsDictionary[operationID], rightSide);
        }

        public virtual bool Equals(ISetElement other)
        {
            return RawValue.Equals(other);
        }

        public ISetElement ConvertTo(ISet otherSet, bool Implicitly)
        {
            var result = SupportSet.ConvertToElementInOtherSet(this, otherSet, Implicitly);
            if (result == null)
                result = otherSet.ConvertElementFromOtherSet(this, Implicitly);

            return result;
        }

        public ISetElement ConvertToImplicitly(ISet otherSet)
        {
            return ConvertTo(otherSet, true);
        }

        public ISetElement ConverToExplicitly(ISet otherSet)
        {
            return ConvertTo(otherSet, false);
        }
    }

    public class GenericSetElement<TSupportType> : GenericSetElement, ISetElement<TSupportType>
    {
        public GenericSetElement(ISet supportSet, TSupportType rawValue)
            : base(supportSet, rawValue)
        {
        }
        
        public new TSupportType RawValue
        {
            get { return (TSupportType)base.RawValue; }
        }

        public new ISetElement<TSupportType> PerformUnaryOperation(int operationID)
        {
            return (ISetElement<TSupportType>)base.PerformUnaryOperation(operationID);
        }

        public ISetElement<TSupportType> PerformBinaryOperation(int operationID, ISetElement<TSupportType> rightSide)
        {
            return (ISetElement<TSupportType>)base.PerformBinaryOperation(operationID, rightSide);
        }

        public new ISetElement<TSupportType> PerformUnaryOperation(string operationID)
        {
            return (ISetElement<TSupportType>)base.PerformUnaryOperation(operationID);
        }

        public ISetElement<TSupportType> PerformBinaryOperation(string operationID, ISetElement<TSupportType> rightSide)
        {
            return (ISetElement<TSupportType>)base.PerformBinaryOperation(operationID, rightSide);
        }
    }
}
