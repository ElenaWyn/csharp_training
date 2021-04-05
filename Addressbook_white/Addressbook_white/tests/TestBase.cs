using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Linq;

namespace Addressbook_white
{
    
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp]
        public void Initapp()
        {
            app = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void StopApp()
        {
            app.Stop();
        }

    }
}
