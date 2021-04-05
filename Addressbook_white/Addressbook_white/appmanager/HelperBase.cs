using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Addressbook_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}