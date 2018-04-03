using Hui_Demo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Hui_Demo.Helper
{
    public class CheckHelp
    {
        public static Dictionary<int, string> CheckUser(IEnumerable<User> models)
        {
            var ctx = ContextHelper.Create();
            Dictionary<int, string> result = new Dictionary<int, string>();
            string error;
            int count = 0;
            var User = ctx.User.ToList();
            foreach (var model in User)
            {
                bool flag = true;
                error = string.Empty;
                if (String.IsNullOrEmpty(model.UserName))
                {
                    error += "用户名不能为空; ";
                    flag = false;
                }
                if (String.IsNullOrEmpty(model.UserPassword))
                {
                    error += "用户密码不能为空; ";
                    flag = false;
                }
                if (String.IsNullOrEmpty(model.Name))
                {
                    error += "姓名不能为空; ";
                    flag = false;
                }
                //检查数据在数据库中是否已存在
                if (flag && model.UserName != "")
                {
                    var Count = User.Count(x => x.UserName == model.UserName && x.DeleteFlag == false);
                    if (Count > 0)
                        error += "此用户名在数据库中已存在; ";
                }
                result.Add(count, error);
                count++;
            }
            return result;
        }
        public static bool CheckUserName(string UserName)
        {
            var ctx = ContextHelper.Create();
            User u = new User();
            if (u.UserName == UserName)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}