using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class GroupData
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
