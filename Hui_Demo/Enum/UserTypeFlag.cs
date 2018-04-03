using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Enum
{
    public class UserTypeFlag
    {
        
        public const int 内部 = 0;
        public const int 外部 = 1; 

        public static string Render(int value)
        {
            switch (value)
            {
                case 内部: return "内部";
                case 外部: return "外部";
                default: return "";
            }
        }
    }
}