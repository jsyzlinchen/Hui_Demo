using Hui_Demo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Helper
{
    public static  class EnumHelper
    {
        public static string RenderUserTypeFlag(this int T)
        {
            return UserTypeFlag.Render(T);
        }

        public static string RenderGenderTypeFlag(this int T)
        {
            return GenderTypeFlag.Render(T);
        }

        public static string RenderPostTypeFlag(this int T)
        {
            return PostTypeFlag.Render(T);
        }
    }
}