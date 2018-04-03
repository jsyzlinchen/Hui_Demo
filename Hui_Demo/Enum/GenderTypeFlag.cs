using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Enum
{
    public class GenderTypeFlag
    {
        public const int 男 = 0;
        public const int 女 = 1;

        public static string Render(int T)
        {
            switch (T)
            {
                case 男: return "男";
                case 女: return "女";
                default:return "";
            }
        }

    }
}