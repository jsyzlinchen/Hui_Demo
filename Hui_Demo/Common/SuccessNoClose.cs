using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hui_Demo.Common
{
    public class SuccessNoClose : _Result
    {
        public SuccessNoClose()
        {
            statusCode = "200";
            closeCurrent = false;
            message = "操作成功";
            tabid = "List";
        }
    }
}