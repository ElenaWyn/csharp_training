using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    
    [Table(Name = "group_list")]

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

        
        [Column(Name ="group_name"), NotNull]
        public string Groupname { get; set;  }
        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }
        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
        
        public List<ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id)
                        select c).Distinct().ToList();
                // && c.Deprecated == "0000-00-00 00:00:00"
            }
        }
    }
}
