using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }
        public GroupData(string groupname)
        {
            Groupname = groupname;
        }

        public GroupData(string groupname, string header, string footer)
        {
            Groupname = groupname;
            Footer = footer;
            Header = header;
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
            return "Name= " + Groupname + "\nheader= " + Header + "\nfooter = " + Footer;
        }


        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Groupname.CompareTo(other.Groupname);
        }

        
        public string Groupname { get; set;  }
       
        public string Header { get; set; }       

        public string Footer { get; set; }

        public string Id { get; set; }
        
    }
}
