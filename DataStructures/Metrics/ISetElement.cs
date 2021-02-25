using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public interface ISetElement: IEquatable<ISetElement>
    {
        ISet SupportSet { get; }

        object RawValue { get; }

        ISetElement ConvertToImplicitly(ISet otherSet);
        ISetElement ConverToExplicitly(ISet otherSet);

        ISetElement PerformUnaryOperation(int operationID);
        ISetElement PerformBinaryOperation(int operationID, ISetElement rightSide);

        ISetElement PerformUnaryOperation(string operationID);
        ISetElement PerformBinaryOperation(string operationID, ISetElement rightSide);
    }

    public interface ISetElement<TSupportType> : ISetElement
    {
        new TSupportType RawValue { get; }

        new ISetElement<TSupportType> PerformUnaryOperation(int operationID);
        ISetElement<TSupportType> PerformBinaryOperation(int operationID, ISetElement<TSupportType> rightSide);

        new ISetElement<TSupportType> PerformUnaryOperation(string operationID);
        ISetElement<TSupportType> PerformBinaryOperation(string operationID, ISetElement<TSupportType> rightSide);
    }
}
