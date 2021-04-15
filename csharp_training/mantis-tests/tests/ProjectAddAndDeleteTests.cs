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
            Dictionary<string, string> oldProjects = app.Proj.GetProjectsList();
            string projectName = GenerateRandomString(10);
            app.Proj.CreateNewProject(projectName);
            app.Proj.GoToProjectsPage();
            IWebElement pr = app.Driver.FindElement(By.LinkText(projectName));
            KeyValuePair<string, string> projToManipulate = app.Proj.projectToManipulate(pr);
            
            Dictionary<string, string> newProjects = app.Proj.GetProjectsList();
            newProjects.Remove(projToManipulate.Key);

            oldProjects.Values.OrderBy(v=>v);
            newProjects.Values.OrderBy(v => v);

            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void ProjectDeleteTest()
        {
            app.Proj.GoToProjectsPage();
            Dictionary<string, string> oldProjects = app.Proj.GetProjectsList();
            if (oldProjects.Count == 0)
            {
                app.Proj.CreateNewProject(GenerateRandomString(10));
            }
            Random rn = new Random();
            int which = rn.Next(1, oldProjects.Count);
            List<KeyValuePair<string, string>> listOfProjects =  oldProjects.ToList<KeyValuePair<string, string>>();
            KeyValuePair<string, string> projectToDelete = listOfProjects[which];
            string name = projectToDelete.Key;
            app.Proj.DeleteProject(name);
            oldProjects.Remove(name);
            
            Dictionary<string, string> newProjects = app.Proj.GetProjectsList();
            oldProjects.Values.OrderBy(v => v);
            newProjects.Values.OrderBy(v => v);

            Assert.AreEqual(oldProjects, newProjects);

        }

        
    }
}
