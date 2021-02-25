using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public class BasicUnaryOperation : BasicOperation, IUnarySetOperation
    {
        public BasicUnaryOperation(ISet supportSet, Func<object, object> operation, object neutralElement = null)
            : base(supportSet, neutralElement)
        {
            m_operation = operation;
            Operation = new Func<ISetElement, ISetElement>(DoOperation);
        }

        protected ISetElement DoOperation(ISetElement element)
        {
            if (!CheckArgs(element))
                return null;

            return GetResult(m_operation.Invoke(element.RawValue));
        }

        protected Func<object, object> m_operation;

        public virtual Func<ISetElement, ISetElement> Operation
        {
            get;
            protected set;
        }
    }

    public class BasicUnaryOperation<TSupportType> : BasicOperation<TSupportType>, IUnarySetOperation
    {
        public BasicUnaryOperation(ISet<TSupportType> supportSet, Func<TSupportType, TSupportType> operation, TSupportType neutralElement)
            : base(supportSet, neutralElement)
        {
            m_operation = operation;
            Operation = new Func<ISetElement<TSupportType>, ISetElement<TSupportType>>(DoOperation);
        }

        protected ISetElement<TSupportType> DoOperation(ISetElement<TSupportType> element)
        {
            if (!CheckArgs(element))
                return null;

            return (ISetElement<TSupportType>)GetResult(m_operation.Invoke(element.RawValue));
        }

        protected Func<TSupportType, TSupportType> m_operation;

        public Func<ISetElement<TSupportType>, ISetElement<TSupportType>> Operation
        {
            get;
            protected set;
        }

        Func<ISetElement, ISetElement> IUnarySetOperation.Operation
        {
            get
            {
                return element => Operation((ISetElement<TSupportType>)element);
            }
        }
    }
}
