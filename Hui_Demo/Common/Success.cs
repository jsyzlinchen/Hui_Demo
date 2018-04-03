using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Common
{
    public class Success:_Result
    {
        public Success()
        {
            statusCode = "200";
            closeCurrent = true;
            message = "操作成功";
            tabid = "List";
        }


        public Success(string Message)
        {
            statusCode = "200";
            closeCurrent = true;
            message = Message;
            tabid = "List";
        }
    }
}