using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {        
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Company { get; set; }
        public string Telhome { get; set; }

        public string Telwork { get; set; }
        public string Telmobile { get; set; }

        public string Fax { get; set; }
        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }


        public string Address2 { get; set; }

        public string Home { get; set; }

        public string Notes { get; set; }
        
        public string Id { get; set; }





        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            if (Firstname == other.Firstname && Lastname == other.Lastname)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int name = Firstname.GetHashCode();
            int surname = Lastname.GetHashCode();
            return name + surname;
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
               return Lastname.CompareTo(other.Lastname);
            }

        }

    }
}
