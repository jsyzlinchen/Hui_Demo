using Hui_Demo.Helper;
using Hui_Demo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hui_Demo.Controllers
{
    public class RegisterController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register(string Name, string UserName, string UserPassword, string ConfirmPassword)
        {
            var ctx = ContextHelper.Create();
            User u = new User();
            var query = ctx.User.AsQueryable();
            //query = query.FirstOrDefault(x => x.UserName==UserName);
            var model = ctx.User.FirstOrDefault(x => x.UserName == UserName);
            if (String.IsNullOrEmpty(UserName))
            {
                return Content("<script >alert('用户名不能为空！');window.history.go(-1);</script>");
            }
            if (model != null)
            {
                return Content("<script >alert('用户名已存在！');window.history.go(-1);</script>");
            }
            else
            {
                u.Name = Name;
                u.UserName = UserName;
                u.UserPassword = UserPassword;
                u.ConfirmPassword = ConfirmPassword;
                u.CreatTime = DateTime.Now;
                u.LogTime = DateTime.Now;
                u.LastTime = DateTime.Now;
                ctx.User.Add(u);
                ctx.SaveChangesAsync();
                //return Json(new Success());
                return Content("<script >alert('注册成功！');window.history.go(-1);</script>");
            }
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Update(string Name, string Phone, int Age, int Gender, string Portrait)   //更新个人信息
        {
            var ctx = ContextHelper.Create();
            User u = new User();
            var user = AccountHelper.GetUser();
            var query = ctx.User.AsQueryable();
            //query = query.FirstOrDefault(x => x.UserName==UserName);
            var model = ctx.User.FirstOrDefault(x => x.ID == user.ID);
            u.Name = Name;
            u.Phone = Phone;
            u.Age = Age;
            u.Gender = Gender;
            u.Portrait = Portrait;
            ctx.SaveChangesAsync();
            //return Json(new Success());
            return Content("<script >alert('修改成功！');window.history.go(-1);</script>");
        }
    }
}