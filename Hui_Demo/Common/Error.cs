using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Common
{
    public class Error:_Result
    {
        public Error()
        {
            statusCode = "300";
            closeCurrent = false;
            message = "操作失败";
        }


        public Error(string Message)
        {
            statusCode = "300";
            closeCurrent = false;
            message = Message;
        }
    }
}