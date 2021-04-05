using System;
using System.Collections.Generic;
using System.Text;


namespace Addressbook_white
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string Name { get; set; }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Name == other.Name;

        }

        public int CompareTo(GroupData someGroup)
        {
            if (Object.ReferenceEquals(someGroup, null))
            {
                return 1;
            }
            return Name.CompareTo(someGroup.Name);
        }
    }
}
