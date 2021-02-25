using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public class BasicBinaryOperation : BasicOperation, IBinarySetOperation
    {
        public BasicBinaryOperation(ISet supportSet, Func<object, object, object> operation, object neutralElement = null, bool isAssociative = true, bool isCommutative = true)
            : base(supportSet, neutralElement)
        {
            m_operation = operation;
            IsAssociative = isAssociative;
            IsCommutative = isCommutative;
            Operation = new Func<ISetElement, ISetElement, ISetElement>(DoOperation);
        }

        protected virtual ISetElement DoOperation(ISetElement leftSide, ISetElement rightSide)
        {
            if (!CheckArgs(leftSide, rightSide))
                return null;

            return GetResult(m_operation.Invoke(leftSide.RawValue, rightSide.RawValue));
        }

        protected Func<object, object, object> m_operation;

        public virtual Func<ISetElement, ISetElement, ISetElement> Operation
        {
            get;
            protected set;
        }

        public bool IsCommutative
        {
            get;
            protected set;
        }

        public bool IsAssociative
        {
            get;
            protected set;
        }
        
        protected IUnarySetOperation _InverseWithRegardToOperation;

        public IUnarySetOperation InverseWithRegardToOperation
        {
            get { return _InverseWithRegardToOperation; }
            set
            {
                if (!SupportSet.Equals(value.SupportSet))
                    throw new ArgumentException("Specified operation does not operate on the same set.");

                _InverseWithRegardToOperation = value;
            }
        }
    }

    public class BasicBinaryOperation<TSupportType> : BasicOperation<TSupportType>, IBinarySetOperation
    {
        public BasicBinaryOperation(ISet<TSupportType> supportSet, Func<TSupportType, TSupportType, TSupportType> operation, TSupportType neutralElement, bool isAssociative = true, bool isCommutative = true)
            : base(supportSet, neutralElement)
        {
            m_typedoperation = operation;
            IsAssociative = isAssociative;
            IsCommutative = isCommutative;
            Operation = new Func<ISetElement<TSupportType>, ISetElement<TSupportType>, ISetElement<TSupportType>>(DoOperation);
        }

        protected Func<TSupportType, TSupportType, TSupportType> m_typedoperation;

        protected ISetElement<TSupportType> DoOperation(ISetElement<TSupportType> leftSide, ISetElement<TSupportType> rightSide)
        {
            if (!CheckArgs(leftSide, rightSide))
                return null;

            return GetResult(m_typedoperation.Invoke(leftSide.RawValue, rightSide.RawValue)) as ISetElement<TSupportType>;
        }

        public Func<ISetElement<TSupportType>, ISetElement<TSupportType>, ISetElement<TSupportType>> Operation
        {
            get;
            protected set;
        }


        public bool IsCommutative
        {
            get;
            protected set;
        }

        public bool IsAssociative
        {
            get;
            protected set;
        }

        Func<ISetElement, ISetElement, ISetElement> IBinarySetOperation.Operation
        {
            get 
            {
                return (left, right) => Operation((ISetElement<TSupportType>)left, (ISetElement<TSupportType>)right);
            }
        }

        protected IUnarySetOperation _InverseWithRegardToOperation;

        public IUnarySetOperation InverseWithRegardToOperation
        {
            get { return _InverseWithRegardToOperation; }
            set
            {
                if (!SupportSet.Equals(value.SupportSet))
                    throw new ArgumentException("Specified operation does not operate on the same set.");

                _InverseWithRegardToOperation = value;
            }
        }
    }
}
