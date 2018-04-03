using Hui_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Helper
{
    public class ContextHelper
    {
        public static DataModel Create()
        {
            return new DataModel();
        }
    }
}