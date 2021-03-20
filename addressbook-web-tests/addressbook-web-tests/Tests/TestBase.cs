using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


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
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();

        }

        public static string GenerateNewPhone()
        {
            string phone = "";
            for (int i = 0; i < 11; i++)
            {
                phone = phone + rnd.Next(0, 9).ToString();
            }
            return phone;

        }

       


    }
}
