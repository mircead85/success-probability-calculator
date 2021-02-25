using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public class WellKnownStructures
    {
        protected WellKnownStructures()
        {
        }

        protected void Initialize()
        {
            MinusOpID = 0;
            AddOpID = 1;
            MulOpID = 2;
            DivOpID = 3;
            InvOpID = 4;

            var setOfIntegers = new GenericSet<int>((val => true), "SetOfIntegers");
            
            BasicUnaryOperation<int> MinusInteger = new BasicUnaryOperation<int>(setOfIntegers, GetFunc<int, int>(GenericUnaryMinus), 0);
            BasicBinaryOperation<int> AddIntegers = new BasicBinaryOperation<int>(setOfIntegers, GetFunc<int,int,int>(GenericAdd), 0);
            BasicBinaryOperation<int> MultiplyIntegers = new BasicBinaryOperation<int>(setOfIntegers, GetFunc<int, int, int>(GenericMultiply), 1);
            BasicBinaryOperation<int> DivideIntegers = new BasicBinaryOperation<int>(setOfIntegers, GetFunc<int, int, int>(GenericDivide), 1, true, false);

            setOfIntegers.AddOperation(MinusInteger, "MinusInteger");
            setOfIntegers.AddOperation(AddIntegers, "AddIntegers");
            setOfIntegers.AddOperation(MultiplyIntegers, "MultiplyIntegers");
            setOfIntegers.AddOperation(DivideIntegers, "DivideIntegers");
            
            var setOfDoubles = new GenericSet<double>((val => true), "SetOfDoubles");
            var MinusDouble = new BasicUnaryOperation<double>(setOfDoubles, GetFunc<double, double>(GenericUnaryMinus), 0.0);
            var AddDoubles = new BasicBinaryOperation<double>(setOfDoubles, GetFunc<double, double, double>(GenericAdd), 0.0);
            var InverseDouble = new BasicUnaryOperation<double>(setOfDoubles, GetFunc<double, double>(GenericUnaryMultiplicationInverse), 1.0);
            var MultiplyDoubles = new BasicBinaryOperation<double>(setOfDoubles, GetFunc<double, double, double>(GenericMultiply), 1.0);
            MultiplyDoubles.InverseWithRegardToOperation = InverseDouble;
            var DivideDoubles = new BasicBinaryOperation<double>(setOfDoubles, GetFunc<double, double, double>(GenericDivide), 1.0, true, false);

            setOfDoubles.AddOperation(MinusDouble, "MinusDouble");
            setOfDoubles.AddOperation(AddDoubles, "AddDoubles");
            setOfDoubles.AddOperation(MultiplyDoubles, "MultiplyDoubles");
            setOfDoubles.AddOperation(DivideDoubles, "DivideDoubles");
            setOfDoubles.AddOperation(InverseDouble, "InverseDouble");

            SetOfIntegers = setOfIntegers;
            SetOfDoubles = setOfDoubles;
            SetOfDecimals = null;
        }

        protected static Func<TIn, TResult> GetFunc<TIn, TResult>(Func<dynamic, dynamic> genericFunc)
        {
            return new Func<TIn, TResult>(val => (TResult)genericFunc.Invoke(val));
        }
        
        protected static Func<TIn1, TIn2, TResult> GetFunc<TIn1, TIn2, TResult>(Func<dynamic, dynamic, dynamic> genericFunc)
        {
            return new Func<TIn1, TIn2, TResult>((left,right) => (TResult)genericFunc.Invoke(left, right));
        }

        protected static Func<dynamic, dynamic> GenericUnaryMinus =
            (val => -val);

        public static Func<dynamic, dynamic, dynamic> GenericAdd =
            (leftSide, rightSide) => (leftSide + rightSide);

        public static Func<dynamic, dynamic, dynamic> GenericMultiply =
            (leftSide, rightSide) => (leftSide * rightSide);

        public static Func<dynamic, dynamic, dynamic> GenericDivide =
            (leftSide, rightSide) => (leftSide / rightSide);

        public static Func<dynamic, dynamic> GenericUnaryMultiplicationInverse =
            (val => 1 / val);

        public int MinusOpID { get; protected set; }
        public int AddOpID { get; protected set; }
        public int MulOpID { get; protected set; }
        public int DivOpID { get; protected set; }
        public int InvOpID { get; protected set; }

        public ISet<Int32> SetOfIntegers { get; protected set; }
        public ISet<Double> SetOfDoubles { get; protected set; }
        public ISet<Decimal> SetOfDecimals { get; protected set; }
        
        public static WellKnownStructures _WellKnownSets = null;
        public static WellKnownStructures Structures
        {
            get
            {
                if (_WellKnownSets == null)
                {
                    _WellKnownSets = new WellKnownStructures();
                    _WellKnownSets.Initialize();
                }

                return _WellKnownSets;
            }
        }
    }
}
