using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Metrics
{
    public class BasicOperation : ISetOperation
    {
        public BasicOperation(ISet supportSet, object neutralElement = null)
        {
            PerformChecks = true;
            SupportSet = supportSet;
            if (neutralElement == null)
                NeutralElement = null;
            else
                if (SupportSet.BelongsToSet(neutralElement))
                    NeutralElement = SupportSet[neutralElement];
                else
                    NeutralElement = null;
        }

        public bool PerformChecks
        {
            get;
            set;
        }
        protected virtual bool CheckArgs(params ISetElement [] rawValueArgs)
        {
            if (!PerformChecks)
                return true;

            if(rawValueArgs.Any(arg => arg == null))
                return false;
            if(rawValueArgs.Any(arg => !SupportSet.Equals(arg.SupportSet)))
                return false;

            return true;
        }

        protected virtual ISetElement GetResult(object rawValue)
        {
            if(SupportSet.BelongsToSet(rawValue))
                return SupportSet[rawValue];
            else return null;
        }
        
        public virtual ISet SupportSet
        {
            get;
            protected set;
        }

        public virtual ISetElement NeutralElement
        {
            get;
            protected set;
        }
    }

    public class BasicOperation<TSupportType> : BasicOperation
    {
        public BasicOperation(ISet<TSupportType> supportSet, TSupportType neutralElement)
            : base(supportSet, neutralElement)
        {
        }

        public new ISet<TSupportType> SupportSet
        {
            get
            {
                return (ISet<TSupportType>)base.SupportSet;
            }
        }
        
        public new ISetElement<TSupportType> NeutralElement
        {
            get
            {
                return base.NeutralElement as ISetElement<TSupportType>;
            }
        }
    }
}
