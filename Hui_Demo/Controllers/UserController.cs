using Hui_Demo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hui_Demo.Enum;
using Hui_Demo.Models.Entities;
using System.Data.Entity;

namespace Hui_Demo.Controllers
{
    public class UserController:_BaseController 
    {
        public ActionResult Index()
        {
            var ctx = ContextHelper.Create();
            var user = ctx.User.AsQueryable();
            //user = user.FirstOrDefault(x => x.DeleteFlag == false);
            user = user.Where(x => x.DeleteFlag == false);
            var list = user.ToList();

            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Save(string Name, string UserName, string UserPassword, string ConfirmPassword, string Phone, string Email, string Sex)
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
                u.Phone = Phone;
                u.Mail = Email;
                u.Gender = Convert.ToInt32(Sex);
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


        public ActionResult Update(User model)
        {
            var ctx = ContextHelper.Create();
            var entity = ctx.User.FirstOrDefault(x => x.ID == model.ID);
            entity.Name= model.Name;
            entity.Phone = model.Phone;
            entity.Age = model.Age;
            entity.Company = model.Company;
            entity.Gender = model.Gender;
            entity.Mail = model.Mail;
            entity.Portrait = model.Portrait;

            ctx.SaveChangesAsync();
            return null;
        }






        public ActionResult Delete(string IDs)
        {
            List<int> idList = new List<int>();
            foreach ( var i in IDs.Split(','))
            {
                var id = Convert.ToInt32(i);
                idList.Add(id);
            }
            var ctx = ContextHelper.Create();
            var list = ctx.User.Where(x => idList.Contains(x.ID));
            ctx.User.RemoveRange(list);
            ctx.SaveChangesAsync();
            return null;
        }

        public ActionResult DeleteFlag(string IDs)
        {
            //假删
            List<int> idList = new List<int>();
            foreach (var i in IDs.Split(','))
            {
                int id = Convert.ToInt32(i);
                idList.Add(id);
            }
            var ctx = ContextHelper.Create();
            var list = ctx.Post.Where(x => idList.Contains(x.ID));   // ctx.Dish.Where
            foreach (var i in list)
            {
                i.DeleteFlag = true;
            }
            ctx.SaveChangesAsync();
            return null;
        }
    }

}