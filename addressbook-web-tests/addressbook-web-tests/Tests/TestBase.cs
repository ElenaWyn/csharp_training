using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    public class TestBase
    {


        protected ApplicationManager app;


       

        [SetUp]
        public void SetupAppManager()
        {
            app = ApplicationManager.GetInstance();

        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
           
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i<l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 233 + 32)));
            }
            return builder.ToString();

        }



    }
}
