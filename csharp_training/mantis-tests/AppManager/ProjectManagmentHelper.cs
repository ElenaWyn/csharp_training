using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagmentHelper : HelperBase
    {
        public ProjectManagmentHelper(ApplicationManager manager) : base(manager) { }
        
        public void GoToProjectsPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("manage-menu-link")));
            driver.FindElement(By.ClassName("manage-menu-link")).Click();
             //driver.FindElement(By.XPath("//*[contains(text(), 'управление')]")).Click();
             driver.FindElement(By.XPath("//*[contains(text(), 'Управление проектами')]")).Click();
        }

        public void CreateNewProject(string projectName)
        {
            driver.FindElement(By.XPath("//input[@value = 'создать новый проект']")).Click();
            driver.FindElement(By.Id("project-name")).SendKeys(projectName);
            driver.FindElement(By.XPath("//input[@value = 'Добавить проект']")).Click();
        }

        public Dictionary<string, string> GetProjectsList()
        {
            GoToProjectsPage();
            Dictionary<string, string> IDs = new Dictionary<string, string>();
            ICollection<IWebElement> projects = driver.FindElements(By.XPath("//tbody/tr//a"));
            foreach (IWebElement pr in projects)
            {
                KeyValuePair<string, string> valueToAdd = projectToManipulate(pr);
                IDs.Add(valueToAdd.Key, valueToAdd.Value);
            }
            return IDs;
        }

        public List<Mantis.ProjectData> GetProjectsListFromWebService(AccountData acc)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(acc.Name, acc.Password);
            List<Mantis.ProjectData> IDs = projects.ToList();
            return IDs;
        }

        public KeyValuePair<string,string> projectToManipulate(IWebElement pr)
        {
            string href = pr.GetAttribute("href");
            Regex id = new Regex("id=\\d*");
            Match match = id.Match(href);
            string nr = match.Value;
            int found = nr.IndexOf("=");
            string value = nr.Substring(found + 1);
            string key = pr.Text;
            return new KeyValuePair<string, string>(key,value);
            
        }

        public void DeleteProject(string projectName)
        {
            GoToProjectsPage();
            driver.FindElement(By.LinkText(projectName)).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.TagName("thead")));
        }

        public List<ProjectData> FromMantisToThisProjectData (List<Mantis.ProjectData> listOfProjects)
        {
            List<ProjectData> list = new List<ProjectData>();
            foreach (Mantis.ProjectData p in listOfProjects)
            {
                ProjectData proj = new ProjectData()
                {
                    ProjectName = p.name,
                    ID = p.id
                };
                list.Add(proj);
            }
            return list;
        }

    }
}
