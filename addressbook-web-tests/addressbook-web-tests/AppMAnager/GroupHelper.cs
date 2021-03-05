using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper RemoveGroup(int groupNR)
        {
            manager.Navigator.GoToGroupsPage();
            ChooseGroup(groupNR);
            DeleteGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper GroupModify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            ChooseGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ChooseGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name = \"selected[]\"])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
             SubmitGroupCreation();
             manager.Navigator.ReturnToGroupsPage();
            return this;
        }

            public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Groupname);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public List<GroupData> GetGroupList()
        {

            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;


        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper IsThereAnyGroup()
        {
            manager.Navigator.GoToGroupsPage();
            if (! IsElementPresent(By.XPath("//input[@name = 'selected[]']")))
            {
                CreateGroup(new GroupData("test"));
            }
            return this;
        }


    }
}
