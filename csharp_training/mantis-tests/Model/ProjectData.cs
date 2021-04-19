using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IComparable<ProjectData>
    {
        public string ID { get; set; }
        public string ProjectName { get; set; }

        

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ID.CompareTo(other.ID);
        }

        public override bool Equals(Object other)
        {
            ProjectData pr = other as ProjectData;
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return ID == pr.ID;
        }
    }
}
