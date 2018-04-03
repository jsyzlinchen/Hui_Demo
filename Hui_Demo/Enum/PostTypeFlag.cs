using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Enum
{
    public class PostTypeFlag
    {
        public const int 是 = 0;
        public const int 否 = 1;

        public static string Render(int T)
        {
            switch (T)
            {
                case 否: return "否";
                case 是: return "是";
                default:return "";
            }
        }

    }
}