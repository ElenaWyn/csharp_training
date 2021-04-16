using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddIssue()
        {
            AccountData acc = new AccountData(){
                Name = "administrator",
                Password = "test"
            };
            IssueData issue = new IssueData()
            {
                Category = "General",
                Summary = "some summary",
                Description = "some description"

            };
            ProjectData project = new ProjectData()
            {
                ID = "1"
            };

            app.APIHelper.CreateNewIssue(acc, issue, project);
        }
    }
}
