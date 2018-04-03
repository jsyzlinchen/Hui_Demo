using Hui_Demo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hui_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet ]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost ]
        public ActionResult Login(int? TypeFlag, string UserName, string UserPassword,string Code)
        {
            SysHelper sys = new SysHelper();
            var ctx = ContextHelper.Create();
            var SysLog = new Hui_Demo.Models.Entities.SysLog();
            var User = ctx.User.FirstOrDefault(x => x.UserName == UserName && x.DeleteFlag == false);
            if (User != null)
            {
                if (User.UserPassword == UserPassword)
                {
                    HttpContext.Application.Lock();
                    //使用Lock就能确保了在某一时段所有连接到服务器的用户之中只有一个用户能获得存取或修改
                    //该Application变量的权限(即对该公共变量进行锁定操作)。其它任何用户想要获得这样的权限
                    //就必须等当前权限用户结束其锁定或者当前ASP程序终止执行。
                    string SessionID = Session.SessionID;
                    string CurrentUser = "$Session_" + User.UserName;
                    //  HttpContext.Application.Add(CurrentUser,SessionID);
                    HttpContext.Application.Set(CurrentUser, SessionID);
                    HttpContext.Application.UnLock();
                    AccountHelper.SaveUser(User);
                    Code = Code.ToString().ToLower();
                    if (Code == Session["VCode"].ToString().ToLower())
                    {
                    }
                    else
                    {
                        return Content("<script >alert('验证码错误！');history.go(-1);</script>");
                    }
                    if (User.TypeFlag == Enum.UserTypeFlag.外部)
                    {
                        User.LogTime = User.LastTime;    //Logtime 记录的是上上次的时间
                        User.LastTime = DateTime.Now;
                        SysLog.Name = User.Name;
                        SysLog.UserName = User.UserName;
                        SysLog.LogTime = DateTime.Now;
                        SysLog.Title = sys.GetHostAddress();
                        SysLog.TypeFlag = User.TypeFlag;
                        ctx.SysLog.Add(SysLog);
                        ctx.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        SysLog.Name = User.Name;
                        SysLog.UserName  = User.UserName;
                        SysLog.LogTime = DateTime.Now;
                        SysLog.Title = sys.GetHostAddress();
                        SysLog.TypeFlag = User.TypeFlag;
                        ctx.SysLog.Add(SysLog);
                        User.LogTime = User.LastTime;    //Logtime 记录的是上上次的时间
                        User.LastTime = DateTime.Now;
                        ctx.SaveChanges();
                        return RedirectToAction("Index", "Home", new { Area = "Manage" });
                    }
                }
                else
                {
                    return Content("<script >alert('用户名或者密码错误！');history.go(-1);</script>"); 
                   
                }
            }
            else
            {
                return Content("<script >alert('用户名或者密码错误！');history.go(-1)</script>");
            }
        }

        public ActionResult Welcome()
        {
            return View();
        }

    }
}