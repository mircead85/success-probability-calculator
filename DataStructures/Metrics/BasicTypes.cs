using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public interface IID : ICloneable
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }

        void SetID(Guid Id, string name, string description);
        void SetID(ID newID);
        ID BasicID { get; }

        int GetHashCode();
    }

    [Serializable]
    public class ID : IID
    {
        protected Guid _id;
        protected string _Name;
        protected string _Description;

        protected ID _BasicID;

        protected bool IsReadOnly;

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (IsReadOnly)
                    throw new ApplicationException("Access denined.");
                _id = value;
                _BasicID._id = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (IsReadOnly)
                    throw new Exception("Access denined.");
                _Name = value;
                _BasicID._Name = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (IsReadOnly)
                    throw new Exception("Access denined.");
                _Description = value;
                _BasicID._Description = value;
            }
        }

        protected virtual Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }

        public ID()
        {
            IsReadOnly = false;
            _id = GetNewGuid();
            _Name = "<NONAME>";
            _Description = "<NO DESCRIPTION>";
            _BasicID = new ID(_id, _Name, _Description);
            _BasicID.IsReadOnly = true;
        }

        public virtual void SetID(Guid Id, string name, string description)
        {
            if (IsReadOnly)
                throw new Exception("Access denined.");

            if (Id != Guid.Empty)
            {
                _id = Id;
                _BasicID._id = Id;
            }
            if (name != null)
            {
                _Name = name;
                _BasicID._Name = name;
            }
            if (_Description != null)
            {
                _Description = description;
                _BasicID.Description = description;
            }
        }

        public void SetID(ID newID)
        {
            SetID(newID._id, newID._Name, newID._Description);
        }

        public ID(Guid Id, string name, string description)
            : this()
        {
            SetID(Id, name, description);
        }

        public static ID Empty
        {
            get
            {
                return new ID(Guid.Empty, "", "");
            }
        }

        public ID BasicID
        {
            get
            {
                return _BasicID;
            }
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ID b = obj as ID;
            if (b == null)
                return base.Equals(obj);
            else
                return _id == b._id;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    public class IDProvider
    {
        public IDProvider()
        {
            Int2Guid = new Dictionary<int, Guid>();
        }

        public virtual Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        protected IDictionary<int, Guid> Int2Guid;

        public virtual ID FromInt(int p, string name)
        {
            Guid G = Guid.NewGuid();
            if (Int2Guid.ContainsKey(p))
                G = Int2Guid[p];
            return new ID(G, name, name);
        }

        protected int _MaxID = 0;
        protected Hashtable intIDs = new Hashtable();

        public virtual void SetIntID(int iid, ID id)
        {
            intIDs[iid] = id;
        }

        public virtual ID FromInt(int iid)
        {
            return (ID)intIDs[iid];
        }
    }

}
