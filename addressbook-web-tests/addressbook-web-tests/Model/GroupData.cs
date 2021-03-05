using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string groupname;
        private string header = "";
        private string footer = "";

        public GroupData(string groupname)
        {
            this.groupname = groupname;
        }

        public GroupData(string groupname, string header, string footer)
        {
            this.groupname = groupname;
            this.footer = footer;
            this.header = header;
        }

        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Groupname == other.Groupname;
        }

        public override int GetHashCode()
        {
            return Groupname.GetHashCode();
        }

        public override string ToString()
        {
            return Groupname;
        }


        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Groupname.CompareTo(other.Groupname);
        }

        
        public string Groupname
        {
            get
            {
                return groupname;
            }
            set
            {
                groupname = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

        
    }
}
