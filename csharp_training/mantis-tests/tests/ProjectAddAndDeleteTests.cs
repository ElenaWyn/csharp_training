using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectAddAndDeleteTests : TestBase
    {
        AccountData acc = new AccountData()
        {
            Name = "administrator",
            Password = "test"
        };

        [TestFixtureSetUp]
        public void LogInSetUp()
        {
            app.Login.CheckIfAccountIsLogedIn();
            app.Login.LogIn(acc);
        }

        [Test]
        public void ProjectAddTest()
        {
            app.Proj.GoToProjectsPage();
            List<Mantis.ProjectData> oldProjects = app.Proj.GetProjectsListFromWebService(acc);
            //Dictionary<string, string> oldProjects = app.Proj.GetProjectsList();
            string projectName = GenerateRandomString(10);
            app.Proj.CreateNewProject(projectName);
            app.Proj.GoToProjectsPage();
            IWebElement pr = app.Driver.FindElement(By.LinkText(projectName));
            KeyValuePair<string, string> projToManipulate = app.Proj.projectToManipulate(pr);
            
            //Dictionary<string, string> newProjects = app.Proj.GetProjectsList();
            List<Mantis.ProjectData> newProjects = app.Proj.GetProjectsListFromWebService(acc);
            Mantis.ProjectData newProject = new Mantis.ProjectData();
            newProject.id = projToManipulate.Value;
            newProject.name = projToManipulate.Key;
            oldProjects.Add(newProject);

            List<ProjectData> old = app.Proj.FromMantisToThisProjectData(oldProjects);
            List<ProjectData> afterChanges = app.Proj.FromMantisToThisProjectData(newProjects);
            old.Sort();
            afterChanges.Sort();

            //oldProjects.Values.OrderBy(v=>v);
            //newProjects.Values.OrderBy(v => v);

            Assert.AreEqual(old, afterChanges);
        }

        [Test]
        public void ProjectDeleteTest()
        {
            //app.Proj.GoToProjectsPage();
            //Dictionary<string, string> oldProjects = app.Proj.GetProjectsList();
            List<Mantis.ProjectData> oldProjects = app.Proj.GetProjectsListFromWebService(acc);
            if (oldProjects.Count == 0)
            {
                //app.Proj.CreateNewProject(GenerateRandomString(10));
                app.APIHelper.CreateNewProject(acc);
                oldProjects = app.Proj.GetProjectsListFromWebService(acc);
            }
            Random rn = new Random();
            int which = rn.Next(1, oldProjects.Count);
            Mantis.ProjectData projectToDelete = oldProjects[which];
            //List<KeyValuePair<string, string>> listOfProjects =  oldProjects.ToList<KeyValuePair<string, string>>();
            //KeyValuePair<string, string> projectToDelete = listOfProjects[which];
            //string name = projectToDelete.Key;
            app.Proj.DeleteProject(projectToDelete.name);
            oldProjects.Remove(projectToDelete);

            //Dictionary<string, string> newProjects = app.Proj.GetProjectsList();
            List<Mantis.ProjectData> newProjects = app.Proj.GetProjectsListFromWebService(acc);

            //oldProjects.Values.OrderBy(v => v);
            //newProjects.Values.OrderBy(v => v);

            List<ProjectData> old = app.Proj.FromMantisToThisProjectData(oldProjects);
            List<ProjectData> afterChanges = app.Proj.FromMantisToThisProjectData(newProjects);
            old.Sort();
            afterChanges.Sort();

            Assert.AreEqual(old, afterChanges);

        }

        
    }
}
