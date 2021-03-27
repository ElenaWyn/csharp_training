using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using NUnit.Framework;

namespace addressbook_web_tests
{

    [Table(Name = "addressbook")]
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string allPhones;
        public string allMails;

        
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {
        }
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "home")]
        public string Telhome { get; set; }
        [Column(Name = "work")]
        public string Telwork { get; set; }
        [Column(Name = "mobile")]
        public string Telmobile { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string Bday { get; set; }
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }
        [Column(Name = "byear")]
        public string Byear { get; set; }
        [Column(Name = "aday")]
        public string Aday { get; set; }
        [Column(Name = "amonth")]
        public string Amonth { get; set; }
        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string Home { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "id")]
        public string Deprecated { get; set; }

        public string AllPhones {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Telhome) + CleanUp(Telmobile) + CleanUp(Telwork) + CleanUp(Home)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }

            }
            set
            {
                allMails = value;
            }
        }

        private string CleanUp(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            else
            {
                //return value.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
                return Regex.Replace(value, "[ -()]", "") + "\r\n";
            }
        }

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

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        

        public List<GroupData> GetGroups()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
               return (from g in db.Groups
                        from gcr in db.GCR.Where(p => p.ContactId == Id && p.GroupId == g.Id)
                        select g).Distinct().ToList();

            }
        }



    }
}
