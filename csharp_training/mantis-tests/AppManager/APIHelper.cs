using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, IssueData issue, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData bug = new Mantis.IssueData();
            bug.summary = issue.Summary;
             bug.description = issue.Description;
            bug.category = issue.Category;
            bug.project = new Mantis.ObjectRef();
            bug.project.id = project.ID;
            client.mc_issue_add(account.Name, account.Password, bug);
        }

        public ProjectData CreateNewProject(AccountData acc)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData proj = new Mantis.ProjectData();

            Random rnd = new Random();
            string name = new String(Enumerable.Range(0, 10).Select(n => (Char)(rnd.Next(32, 127))).ToArray());
            proj.name = name;
            client.mc_project_add(acc.Name, acc.Password, proj);
            proj.id = client.mc_project_get_id_from_name(acc.Name, acc.Password, proj.name);
            ProjectData project = new ProjectData()
            {
                ProjectName = proj.name,
                ID = proj.id
            };
            return project;
        }
    }

    
}
